namespace Platform::Random::Tests
{
    TEST(RandomExtensionsTests, NextUInt64Test)
    {
        auto lastValue = 0UL;
        auto theSameCount = 0;
        for (auto i = 0; i < 10; i++)
        {
            auto newValue = NextUInt64(RandomHelpers::Default);
            if (newValue == lastValue)
            {
                ++theSameCount;
            }
            else
            {
                lastValue = newValue;
                theSameCount = 0;
            }

            std::uint64_t temp = NextUInt64(RandomHelpers::Default, {0UL, 5UL});
            ASSERT_LT(temp, 5UL);
            ASSERT_GT(temp, 0UL);
        }
        ASSERT_LT(theSameCount, 8);
    }

    TEST(RandomExtensionsTests, NextBooleanTest)
    {
        auto trueCount = 0;
        auto falseCount = 0;
        for (auto i = 0; i < 10; ++i)
        {
            auto newValue = NextBoolean(RandomHelpers::Default);
            if (newValue)
            {
                ++trueCount;
            }
            else
            {
                ++falseCount;
            }
        }
        ASSERT_GT(trueCount, 0);
        ASSERT_GT(falseCount, 0);
    }
}
