#include <Platform.Random.h>
#include <gtest/gtest.h>

namespace Platform::Random::Tests
{
    TEST(RandomHelpersTests, DefaultFieldTest)
    {
        ASSERT_NE(RandomHelpers::Default, nullptr);
    };
}
