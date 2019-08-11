namespace Platform.Random
{
    public static class RandomHelpers
    {
        /// <summary>
        /// Returns the pseudorandom number generator that is using the time of the first access to this field as seed.
        /// Возвращает генератор псевдослучайных чисел использующий в качестве seed время первого обращения к этому полю.
        /// </summary>
        public static readonly System.Random Default = new System.Random(System.DateTime.UtcNow.Ticks.GetHashCode());
    }
}
