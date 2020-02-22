using Xunit;

namespace Platform.Random.Tests
{
    public class RandomExtensionsTests
    {
        [Fact]
        public void NextUInt64Test()
        {
            var lastValue = 0UL;
            var theSameCount = 0;
            for (var i = 0; i < 10; i++)
            {
                var newValue = RandomHelpers.Default.NextUInt64();
                if (newValue == lastValue)
                {
                    theSameCount++;
                }
                else
                {
                    lastValue = newValue;
                    theSameCount = 0;
                }
                Assert.InRange(RandomHelpers.Default.NextUInt64((0UL, 5UL)), 0UL, 5UL);
            }
            Assert.True(theSameCount < 8);
        }

        [Fact]
        public void NextBooleanTest()
        {
            var trueCount = 0;
            var falseCount = 0;
            for (var i = 0; i < 10; i++)
            {
                var newValue = RandomHelpers.Default.NextBoolean();
                if (newValue)
                {
                    trueCount++;
                }
                else
                {
                    falseCount++;
                }
            }
            Assert.True(trueCount > 0);
            Assert.True(falseCount > 0);
        }
    }
}
