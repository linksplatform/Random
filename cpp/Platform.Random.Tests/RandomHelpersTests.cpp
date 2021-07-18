namespace Platform::Random::Tests
{
    TEST(RandomHelpersTests, DefaultFieldTest)
    {
        ASSERT_NE(RandomHelpers::Default, decltype(RandomHelpers::Default){});
    };
}
