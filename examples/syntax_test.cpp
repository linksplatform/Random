#include <random>
#include <type_traits>

// Mock the Range structure for syntax check
namespace Ranges {
    template<typename T>
    struct Range {
        T Minimum;
        T Maximum;
    };
    
    inline Range<std::uint8_t> UInt8{0, 255};
    inline Range<std::uint16_t> UInt16{0, 65535};
    inline Range<std::uint32_t> UInt32{0, 4294967295U};
    inline Range<std::uint64_t> UInt64{0UL, 18446744073709551615UL};
}

// Copy of our implementation
namespace Platform::Random
{
    template<typename T>
    T NextUInt(std::mt19937_64& random, const Ranges::Range<T>& range) 
    { 
        static_assert(std::is_unsigned_v<T>, "T must be an unsigned integer type");
        return std::uniform_int_distribution<T>{range.Minimum, range.Maximum}(random); 
    }

    template<typename T>
    T NextUInt(std::mt19937_64& random) 
    { 
        static_assert(std::is_unsigned_v<T>, "T must be an unsigned integer type");
        if constexpr (std::is_same_v<T, std::uint8_t>) return NextUInt<T>(random, Ranges::UInt8);
        else if constexpr (std::is_same_v<T, std::uint16_t>) return NextUInt<T>(random, Ranges::UInt16);
        else if constexpr (std::is_same_v<T, std::uint32_t>) return NextUInt<T>(random, Ranges::UInt32);
        else if constexpr (std::is_same_v<T, std::uint64_t>) return NextUInt<T>(random, Ranges::UInt64);
        else static_assert(std::false_type::value, "Unsupported unsigned integer type");
    }

    std::uint64_t NextUInt64(std::mt19937_64& random, const Ranges::Range<std::uint64_t>& range) { return NextUInt<std::uint64_t>(random, range); }

    std::uint64_t NextUInt64(std::mt19937_64& random) { return NextUInt<std::uint64_t>(random); }

    bool NextBoolean(std::mt19937_64& random) { return std::uniform_int_distribution<int>{}(random) % 2 == 0; }
}

int main() {
    std::mt19937_64 rng;
    
    // Test the template functions
    auto val8 = Platform::Random::NextUInt<std::uint8_t>(rng);
    auto val16 = Platform::Random::NextUInt<std::uint16_t>(rng);
    auto val32 = Platform::Random::NextUInt<std::uint32_t>(rng);
    auto val64 = Platform::Random::NextUInt<std::uint64_t>(rng);
    
    // Test with ranges
    auto ranged8 = Platform::Random::NextUInt<std::uint8_t>(rng, {0, 10});
    auto ranged64 = Platform::Random::NextUInt<std::uint64_t>(rng, {0UL, 100UL});
    
    // Test existing functions still work
    auto oldVal = Platform::Random::NextUInt64(rng);
    auto oldRanged = Platform::Random::NextUInt64(rng, {0UL, 50UL});
    
    return 0;
}