namespace Platform::Random
{
    std::uint64_t NextUInt64(std::mt19937_64& random, const Ranges::Range<std::uint64_t>& range) { return std::uniform_int_distribution<std::uint64_t>{range.Minimum, range.Maximum}(random); }

    std::uint64_t NextUInt64(std::mt19937_64& random) { return NextUInt64(random, Ranges::UInt64); }

    bool NextBoolean(std::mt19937_64& random) { return std::uniform_int_distribution<int>{}(random) % 2 == 0; }
}
