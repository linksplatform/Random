#include <Platform.Random.h>
#include <gtest/gtest.h>

namespace Platform::Random::Tests
{
    TEST(RandomExtensionsTests, NextUInt64Test)
    {
        auto lastValue = 0UL;
        auto theSameCount = 0;
        for (auto i = 0; i < 10; i++)
        {
            auto newValue = std::uniform_int_distribution<std::uint64_t>()(RandomHelpers::Default);
            if (newValue == lastValue)
            {
                theSameCount++;
            }
            else
            {
                lastValue = newValue;
                theSameCount = 0;
            }
                Assert.InRange(RandomHelpers::Default.NextUInt64({0UL, 5UL}), 0UL, 5UL);
            }
            Assert::IsTrue(theSameCount < 8);
        }

        public: TEST_METHOD(NextBooleanTest)
        {
            auto trueCount = 0;
            auto falseCount = 0;
            for (auto i = 0; i < 10; i++)
            {
                auto newValue = RandomHelpers.Default.NextBoolean();
                if (newValue)
                {
                    trueCount++;
                }
                else
                {
                    falseCount++;
                }
            }
            Assert::IsTrue(trueCount > 0);
            Assert::IsTrue(falseCount > 0);
        }
    };
}
