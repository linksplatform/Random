namespace Platform::Random
{
    static std::uint64_t NextUInt64(std::mt19937_64& random)
    {
        return NextUInt64(random, Ranges::UInt64);
    }

    static std::uint64_t NextUInt64(std::mt19937_64& random, const Range<std::uint64_t>& range)
    {
        return std::uniform_int_distribution<std::uint64_t>(range.Minimum, range.Maximum)(random);
    }

    static bool NextBoolean(std::mt19937_64& random)
    {
        return std::uniform_int_distribution<int>(0, 1)(random);
    }
} // namespace Platform::Random
