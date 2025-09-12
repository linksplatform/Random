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
                theSameCount++;
            }
            else
            {
                lastValue = newValue;
                theSameCount = 0;
            }

            std::uint64_t temp = NextUInt64(RandomHelpers::Default, {0UL, 5UL});
            ASSERT_LE(temp, 5UL);
            ASSERT_GE(temp, 0UL);
        }
        ASSERT_LT(theSameCount, 8);
    }

    TEST(RandomExtensionsTests, NextUIntTemplateTest)
    {
        // Test NextUInt with different unsigned integer types
        auto value8 = NextUInt<std::uint8_t>(RandomHelpers::Default);
        auto value16 = NextUInt<std::uint16_t>(RandomHelpers::Default);
        auto value32 = NextUInt<std::uint32_t>(RandomHelpers::Default);
        auto value64 = NextUInt<std::uint64_t>(RandomHelpers::Default);
        
        // Test with ranges
        auto rangedValue8 = NextUInt<std::uint8_t>(RandomHelpers::Default, {0, 10});
        auto rangedValue16 = NextUInt<std::uint16_t>(RandomHelpers::Default, {0, 100});
        auto rangedValue32 = NextUInt<std::uint32_t>(RandomHelpers::Default, {0, 1000});
        auto rangedValue64 = NextUInt<std::uint64_t>(RandomHelpers::Default, {0UL, 10000UL});
        
        // Verify ranges
        ASSERT_LE(rangedValue8, 10);
        ASSERT_GE(rangedValue8, 0);
        ASSERT_LE(rangedValue16, 100);
        ASSERT_GE(rangedValue16, 0);
        ASSERT_LE(rangedValue32, 1000);
        ASSERT_GE(rangedValue32, 0);
        ASSERT_LE(rangedValue64, 10000UL);
        ASSERT_GE(rangedValue64, 0UL);
    }

    TEST(RandomExtensionsTests, NextBooleanTest)
    {
        auto trueCount = 0;
        auto falseCount = 0;
        for (auto i = 0; i < 10; i++)
        {
            auto newValue = NextBoolean(RandomHelpers::Default);
            if (newValue)
            {
                trueCount++;
            }
            else
            {
                falseCount++;
            }
        }
        ASSERT_GT(trueCount, 0);
        ASSERT_GT(falseCount, 0);
    }
}
