namespace Platform::Random::RandomHelpers
{
    std::mt19937_64 Default { std::random_device{}() };
}
