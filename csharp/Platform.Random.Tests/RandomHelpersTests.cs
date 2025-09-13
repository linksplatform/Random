using System.Linq;
using Xunit;

namespace Platform.Random.Tests
{
    public class RandomHelpersTests
    {
        [Fact]
        public void Default_IsNotNull()
        {
            Assert.NotNull(RandomHelpers.Default);
        }

        [Fact]
        public void Default_IsSameInstance()
        {
            var instance1 = RandomHelpers.Default;
            var instance2 = RandomHelpers.Default;
            
            Assert.Same(instance1, instance2);
        }

        [Fact]
        public void Default_IsRandomInstance()
        {
            Assert.IsType<System.Random>(RandomHelpers.Default);
        }

        [Fact]
        public void Default_GeneratesRandomValues()
        {
            var values = new int[100];
            for (var i = 0; i < values.Length; i++)
            {
                values[i] = RandomHelpers.Default.Next();
            }
            
            var uniqueValues = values.Distinct().Count();
            Assert.True(uniqueValues > 50, "Should generate varied random values");
        }

        [Fact]
        public void Default_NextMethodWorks()
        {
            var value = RandomHelpers.Default.Next(0, 100);
            Assert.InRange(value, 0, 99);
        }

        [Fact]
        public void Default_NextDoubleWorks()
        {
            var value = RandomHelpers.Default.NextDouble();
            Assert.InRange(value, 0.0, 1.0);
        }

        [Fact]
        public void DefaultFieldTest()
        {
            Assert.NotNull(RandomHelpers.Default);
        }
    }
}
