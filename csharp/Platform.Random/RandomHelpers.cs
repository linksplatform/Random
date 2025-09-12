namespace Platform.Random
{
    /// <summary>
    /// <para>Contains field-helper for <see cref="System.Random"/> class.</para>
    /// <para>Содержит вспомогательное поле для класса <see cref="System.Random"/>.</para>
    /// </summary>
    public static class RandomHelpers
    {
        /// <summary>
        /// <para>Returns the shared, thread-safe pseudorandom number generator from .NET 6+.</para>
        /// <para>Возвращает разделяемый, потокобезопасный генератор псевдослучайных чисел из .NET 6+.</para>
        /// </summary>
        public static System.Random Default => System.Random.Shared;
    }
}
