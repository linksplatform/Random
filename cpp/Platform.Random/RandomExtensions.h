namespace Platform::Random
{
    class RandomExtensions
    {
        public: static std::uint64_t NextUInt64(System::Random random) { return random.NextUInt64(Range.std::uint64_t); }

        public: static std::uint64_t NextUInt64(System::Random random, Range<std::uint64_t> range) { return (std::uint64_t)(random.NextDouble() * range.Difference()) + range.Minimum; }

        public: static bool NextBoolean(System::Random random) { return random.Next(2) == 1; }
    };
}