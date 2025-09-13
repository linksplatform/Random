using System.Linq;
using Platform.Ranges;
using Xunit;

namespace Platform.Random.Tests
{
    public class RandomExtensionsTests
    {
        [Fact]
        public void NextUInt64_WithoutRange_ReturnsValidValues()
        {
            var random = new System.Random(42);
            var values = new ulong[100];
            
            for (var i = 0; i < values.Length; i++)
            {
                values[i] = random.NextUInt64();
                Assert.InRange(values[i], ulong.MinValue, ulong.MaxValue);
            }
            
            var uniqueValues = values.Distinct().Count();
            Assert.True(uniqueValues > 50, "Should generate varied random values");
        }

        [Fact]
        public void NextUInt64_WithRange_ReturnsValuesInRange()
        {
            var random = new System.Random(42);
            var range = new Range<ulong>(10UL, 20UL);
            
            for (var i = 0; i < 100; i++)
            {
                var value = random.NextUInt64(range);
                Assert.InRange(value, range.Minimum, range.Maximum);
            }
        }

        [Fact]
        public void NextUInt64_WithMinimumRange_ReturnsMinimumValue()
        {
            var random = new System.Random(42);
            var range = new Range<ulong>(5UL, 5UL);
            
            var value = random.NextUInt64(range);
            Assert.Equal(5UL, value);
        }

        [Fact]
        public void NextUInt64_WithLargeRange_ReturnsValidValues()
        {
            var random = new System.Random(42);
            var range = new Range<ulong>(ulong.MaxValue - 1000UL, ulong.MaxValue);
            
            for (var i = 0; i < 10; i++)
            {
                var value = random.NextUInt64(range);
                Assert.InRange(value, range.Minimum, range.Maximum);
            }
        }

        [Fact]
        public void NextUInt64_WithZeroRange_ReturnsZero()
        {
            var random = new System.Random(42);
            var range = new Range<ulong>(0UL, 0UL);
            
            var value = random.NextUInt64(range);
            Assert.Equal(0UL, value);
        }

        [Fact]
        public void NextUInt64_WithDifferentSeeds_GeneratesDifferentSequences()
        {
            var random1 = new System.Random(1);
            var random2 = new System.Random(2);
            var range = new Range<ulong>(0UL, 1000UL);
            
            var values1 = new ulong[10];
            var values2 = new ulong[10];
            
            for (var i = 0; i < 10; i++)
            {
                values1[i] = random1.NextUInt64(range);
                values2[i] = random2.NextUInt64(range);
            }
            
            Assert.NotEqual(values1, values2);
        }

        [Fact]
        public void NextBoolean_GeneratesBothTrueAndFalse()
        {
            var random = new System.Random(42);
            var trueCount = 0;
            var falseCount = 0;
            
            for (var i = 0; i < 1000; i++)
            {
                var value = random.NextBoolean();
                if (value)
                {
                    trueCount++;
                }
                else
                {
                    falseCount++;
                }
            }
            
            Assert.True(trueCount > 0, "Should generate at least one true value");
            Assert.True(falseCount > 0, "Should generate at least one false value");
            Assert.InRange(trueCount, 300, 700);
            Assert.InRange(falseCount, 300, 700);
        }

        [Fact]
        public void NextBoolean_WithSameSeed_GeneratesSameSequence()
        {
            var random1 = new System.Random(123);
            var random2 = new System.Random(123);
            
            for (var i = 0; i < 10; i++)
            {
                var value1 = random1.NextBoolean();
                var value2 = random2.NextBoolean();
                Assert.Equal(value1, value2);
            }
        }

        [Fact]
        public void NextBoolean_WithDifferentSeeds_GeneratesDifferentSequences()
        {
            var random1 = new System.Random(1);
            var random2 = new System.Random(2);
            
            var values1 = new bool[20];
            var values2 = new bool[20];
            
            for (var i = 0; i < 20; i++)
            {
                values1[i] = random1.NextBoolean();
                values2[i] = random2.NextBoolean();
            }
            
            Assert.NotEqual(values1, values2);
        }

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
