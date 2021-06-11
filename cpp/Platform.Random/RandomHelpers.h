namespace Platform::Random
{
    class RandomHelpers
    {
        public: static inline std::mt19937_64 Default { std::random_device{}() };
    };
} // namespace Platform::Random
