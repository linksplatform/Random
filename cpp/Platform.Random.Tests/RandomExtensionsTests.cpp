#include <Platform.Random.h>

namespace Platform::Random::Tests
{
    TEST_CLASS(RandomExtensionsTests)
    {
        public: TEST_METHOD(NextUInt64Test)
        {
            auto lastValue = 0UL;
            auto theSameCount = 0;
            for (auto i = 0; i < 10; i++)
            {
                auto newValue = RandomHelpers.Default.NextUInt64();
                if (newValue == lastValue)
                {
                    theSameCount++;
                }
                else
                {
                    lastValue = newValue;
                    theSameCount = 0;
                }
                Assert.InRange(RandomHelpers.Default.NextUInt64({0UL, 5UL}), 0UL, 5UL);
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
