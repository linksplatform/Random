using Xunit;
using System.Threading.Tasks;
using System.Threading;

namespace Platform.Random.Tests
{
    public class RandomHelpersTests
    {
        [Fact]
        public void DefaultPropertyTest()
        {
            Assert.NotNull(RandomHelpers.Default);
            Assert.Same(RandomHelpers.Default, RandomHelpers.Default);
        }

        [Fact]
        public void ThreadLocalPropertyTest()
        {
            Assert.NotNull(RandomHelpers.ThreadLocal);
            Assert.Same(RandomHelpers.ThreadLocal, RandomHelpers.ThreadLocal);
        }

        [Fact]
        public async Task ThreadLocalPropertyReturnsDifferentInstancesForDifferentThreadsTest()
        {
            System.Random mainThreadRandom = RandomHelpers.ThreadLocal;
            System.Random? otherThreadRandom = null;

            var task = Task.Run(() =>
            {
                otherThreadRandom = RandomHelpers.ThreadLocal;
            });

            await task;

            Assert.NotNull(mainThreadRandom);
            Assert.NotNull(otherThreadRandom);
            Assert.NotSame(mainThreadRandom, otherThreadRandom);
        }

        [Fact]
        public void CreateMethodTest()
        {
            var random1 = RandomHelpers.Create();
            var random2 = RandomHelpers.Create();
            
            Assert.NotNull(random1);
            Assert.NotNull(random2);
            Assert.NotSame(random1, random2);
        }

        [Fact]
        public void CreateWithSeedMethodTest()
        {
            const int seed = 12345;
            var random1 = RandomHelpers.Create(seed);
            var random2 = RandomHelpers.Create(seed);
            
            Assert.NotNull(random1);
            Assert.NotNull(random2);
            Assert.NotSame(random1, random2);
            
            Assert.Equal(random1.Next(100), random2.Next(100));
        }

        [Fact]
        public void CreateSecureMethodTest()
        {
            var secureRandom1 = RandomHelpers.CreateSecure();
            var secureRandom2 = RandomHelpers.CreateSecure();
            
            Assert.NotNull(secureRandom1);
            Assert.NotNull(secureRandom2);
        }
    }
}
