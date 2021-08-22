using Xunit;

namespace Platform.Random.Tests
{
    /// <summary>
    /// <para>
    /// Represents the random extensions tests.
    /// </para>
    /// <para></para>
    /// </summary>
    public class RandomExtensionsTests
    {
        /// <summary>
        /// <para>
        /// Tests that next u int 64 test.
        /// </para>
        /// <para></para>
        /// </summary>
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

        /// <summary>
        /// <para>
        /// Tests that next boolean test.
        /// </para>
        /// <para></para>
        /// </summary>
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
