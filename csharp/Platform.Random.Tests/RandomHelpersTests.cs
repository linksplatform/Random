using Xunit;

namespace Platform.Random.Tests
{
    /// <summary>
    /// <para>
    /// Represents the random helpers tests.
    /// </para>
    /// <para></para>
    /// </summary>
    public class RandomHelpersTests
    {
        /// <summary>
        /// <para>
        /// Tests that default field test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public void DefaultFieldTest()
        {
            Assert.NotNull(RandomHelpers.Default);
        }
    }
}
