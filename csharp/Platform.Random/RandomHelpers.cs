namespace Platform.Random
{
    /// <summary>
    /// <para>Contains field-helper for <see cref="System.Random"/> class.</para>
    /// <para>Содержит вспомогательное поле для класса <see cref="System.Random"/>.</para>
    /// </summary>
    public static class RandomHelpers
    {
        /// <summary>
        /// <para>Returns the pseudorandom number generator that is using the time of the first access to this field as seed.</para>
        /// <para>Возвращает генератор псевдослучайных чисел использующий в качестве seed время первого обращения к этому полю.</para>
        /// </summary>
        public static readonly System.Random Default = new System.Random(System.DateTime.UtcNow.Ticks.GetHashCode());
    }
}
