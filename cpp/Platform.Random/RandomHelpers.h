namespace Platform::Random::RandomHelpers
{
    // FIXME: cert-err58-cpp
    std::mt19937_64 Default { std::random_device{}() };
}
