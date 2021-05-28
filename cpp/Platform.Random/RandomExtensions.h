namespace Platform::Random
{
    class RandomExtensions
    {
        //public: static std::uint64_t NextUInt64(const std::mt19937_64& random) { return random(Range::std::uint64_t); }
        public: static std::uint64_t NextUInt64(const std::mt19937_64& random)
        {
            return std::uniform_int_distribution<std::uint64_t>(Range::UInt64.Minimum, Range::UInt64.Maximum)(random);
        }

        public: static std::uint64_t NextUInt64(const std::mt19937_64& random, const Range<std::uint64_t>& range)
        {
            return std::uniform_int_distribution<std::uint64_t>(range.Minimum, range.Maximum)(random);
        }

        public: static bool NextBoolean(const std::mt19937_64& random)
        {
            return std::uniform_int_distribution<int>(0, 1)(random);
        }
    };
}
