namespace Platform::Random::Tests
{
    decltype(RandomHelpers::Default){}
    TEST(RandomHelpersTests, DefaultFieldTest)
    {
        ASSERT_NE(RandomHelpers::Default, {});
    };
}
