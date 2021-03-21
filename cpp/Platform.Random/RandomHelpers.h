namespace Platform::Random
{
    class RandomHelpers
    {
        public: static readonly System::Random Default = System::Random(System::DateTime::UtcNow::Ticks::GetHashCode());
    };
}
