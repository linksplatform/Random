namespace Platform::Random
{
    static std::uint64_t NextUInt64(std::mt19937_64 random)
    {
        static std::uniform_int_distribution<std::uint64_t> generator(Range::UInt64.Minimum, Range::UInt64.Maximum);
        return generator(random);
    }

    static std::uint64_t NextUInt64(const std::mt19937_64& random, const Range<std::uint64_t>& range)
    {
        return std::uniform_int_distribution<std::uint64_t>(range.Minimum, range.Maximum)(random);
    }

    static bool NextBoolean(const std::mt19937_64& random)
    {
        static std::uniform_int_distribution<int> generator(0, 1);
        return generator(random);
    }
} // namespace Platform::Random
