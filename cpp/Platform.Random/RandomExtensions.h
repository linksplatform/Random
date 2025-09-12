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
