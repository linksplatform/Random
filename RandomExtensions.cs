using System.Runtime.CompilerServices;
using Platform.Ranges;

namespace Platform.Random
{
    /// <summary>
    /// <para>Contains extension methods for Random class.</para>
    /// <para>Содержит методы расширения для класса Random.</para>
    /// </summary>
    public static class RandomExtensions
    {
        /// <summary>
        /// <para>Returns a random 64-bit unsigned integer that is greater than or equal to ulong.MinValue, and less than or equal to ulong.MaxValue.</para>
        /// <para>Возвращает случайное 64-разрядное целое число без знака, которое больше или равно ulong.MinValue и меньше или равно ulong.MaxValue.</para>
        /// </summary>
        /// <param name="random"><para>A pseudo-random number generator.</para><para>Генератор псевдослучайных чисел.</para></param>
        /// <returns>
        /// <para>A 64-bit unsigned integer that is greater than or equal to ulong.MinValue, and less than or equal to ulong.MaxValue.</para>
        /// <para>64-разрядное целое число без знака, которое больше или равно ulong.MinValue и меньше или равно ulong.MaxValue.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong NextUInt64(this System.Random random) => random.NextUInt64((ulong.MinValue, ulong.MaxValue));

        /// <summary>
        /// <para>Returns a random 64-bit unsigned integer that is greater than or equal to minimum of specified range, and less than or equal to maximum of specified range.</para>
        /// <para>Возвращает случайное 64-разрядное целое число без знака, которое больше или равно минимуму указанного диапазона и меньше или равно максимуму указанного диапазона.</para>
        /// </summary>
        /// <param name="random"><para>A pseudo-random number generator.</para><para>Генератор псевдослучайных чисел.</para></param>
        /// <param name="range"><para>The range of possible values.</para><para>Диапазон возможных значений.</para></param>
        /// <returns>
        /// <para>A 64-bit unsigned integer that is greater than or equal to the minimum of specified range, and less than or equal to the maximum of the specified range.</para>
        /// <para>64-разрядное целое число без знака, которое больше или равно минимуму указанного диапазона и меньше или равно максимуму указанного диапазона.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong NextUInt64(this System.Random random, Range<ulong> range) => (ulong)(random.NextDouble() * range.Difference()) + range.Minimum;

        /// <summary>
        /// <para>Return a random boolean value.</para>
        /// <para>Возвращает случайное булево значение.</para>
        /// </summary>
        /// <param name="random"><para>A pseudo-random number generator.</para><para>Генератор псевдослучайных чисел.</para></param>
        /// <returns><para>A random boolean value.</para><para>Случайное булево значение.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NextBoolean(this System.Random random) => random.Next(2) == 1;
    }
}