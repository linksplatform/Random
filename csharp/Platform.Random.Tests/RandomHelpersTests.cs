using Xunit;

namespace Platform.Random.Tests
{
    public class RandomHelpersTests
    {
        [Fact]
        public void DefaultFieldTest()
        {
            Assert.NotNull(RandomHelpers.Default);
        }
    }
}
