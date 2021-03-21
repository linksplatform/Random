namespace Platform::Random::Tests
{
    TEST_CLASS(RandomHelpersTests)
    {
        public: TEST_METHOD(DefaultFieldTest)
        {
            Assert.NotNull(RandomHelpers.Default);
        }
    };
}
