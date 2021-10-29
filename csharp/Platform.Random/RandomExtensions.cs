using System.Runtime.CompilerServices;
using Platform.Ranges;

namespace Platform.Random
{
    /// <summary>
    /// <para>Contains extension methods for <see cref="System.Random"/> class.</para>
    /// <para>Содержит методы расширения для класса <see cref="System.Random"/>.</para>
    /// </summary>
    public static class RandomExtensions
    {
        /// <summary>
        /// <para>Returns a random 64-bit unsigned integer that is greater than or equal to <see cref="ulong.MinValue"/>, and less than or equal to <see cref="ulong.MaxValue"/>.</para>
        /// <para>Возвращает случайное 64-разрядное целое число без знака, которое больше или равно <see cref="ulong.MinValue"/> и меньше или равно <see cref="ulong.MaxValue"/>.</para>
        /// </summary>
        /// <param name="random"><para>A pseudo-random number generator.</para><para>Генератор псевдослучайных чисел.</para></param>
        /// <returns>
        /// <para>A 64-bit unsigned integer that is greater than or equal to <see cref="ulong.MinValue"/>, and less than or equal to <see cref="ulong.MaxValue"/>.</para>
        /// <para>64-разрядное целое число без знака, которое больше или равно <see cref="ulong.MinValue"/> и меньше или равно <see cref="ulong.MaxValue"/>.</para>
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong NextUInt64(this System.Random random) => random.NextUInt64(Range.UInt64);

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
        /// <para>Return a random <see cref="bool"/> value.</para>
        /// <para>Возвращает случайное значение <see cref="bool"/>.</para>
        /// </summary>
        /// <param name="random"><para>A pseudo-random number generator.</para><para>Генератор псевдослучайных чисел.</para></param>
        /// <returns><para>A random <see cref="bool"/> value.</para><para>Случайное значение <see cref="bool"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NextBoolean(this System.Random random) => random.Next(2) == 1;
    }
}