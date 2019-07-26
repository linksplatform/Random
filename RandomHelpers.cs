namespace Platform.Random
{
    public static class RandomHelpers
    {
        public static readonly System.Random Default = new System.Random(System.DateTime.UtcNow.Ticks.GetHashCode());
    }
}
