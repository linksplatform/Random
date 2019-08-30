using System.Runtime.CompilerServices;
using Platform.Ranges;

namespace Platform.Random
{
    /// <summary>
    /// Contains extension methods for Random class.
    /// Содержит методы расширения для класса Random.
    /// </summary>
    public static class RandomExtensions
    {
        /// <summary>
        /// Returns a random 64-bit unsigned integer that is greater than or equal to ulong.MinValue, and less than or equal to ulong.MaxValue.
        /// Возвращает случайное 64-разрядное целое число без знака, которое больше или равно ulong.MinValue и меньше или равно ulong.MaxValue.
        /// </summary>
        /// <param name="random">A pseudo-random number generator. Генератор псевдослучайных чисел.</param>
        /// <returns>A 64-bit unsigned integer that is greater than or equal to ulong.MinValue, and less than or equal to ulong.MaxValue. 64-разрядное целое число без знака, которое больше или равно ulong.MinValue и меньше или равно ulong.MaxValue.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong NextUInt64(this System.Random random) => random.NextUInt64((ulong.MinValue, ulong.MaxValue));

        /// <summary>
        /// Returns a random 64-bit unsigned integer that is greater than or equal to minimum of specified range, and less than or equal to maximum of specified range.
        /// Возвращает случайное 64-разрядное целое число без знака, которое больше или равно минимуму указанного диапазона и меньше или равно максимуму указанного диапазона.
        /// </summary>
        /// <param name="random">A pseudo-random number generator. Генератор псевдослучайных чисел.</param>
        /// <param name="range">The range of possible values. Диапазон возможных значений.</param>
        /// <returns>A 64-bit unsigned integer that is greater than or equal to the minimum of specified range, and less than or equal to the maximum of the specified range. 64-разрядное целое число без знака, которое больше или равно минимуму указанного диапазона и меньше или равно максимуму указанного диапазона.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong NextUInt64(this System.Random random, Range<ulong> range) => (ulong)(random.NextDouble() * range.Difference()) + range.Minimum;

        /// <summary>
        /// Return a random boolean value.
        /// Возвращает случайное булево значение.
        /// </summary>
        /// <param name="random">A pseudo-random number generator. Генератор псевдослучайных чисел.</param>
        /// <returns>A random boolean value. Случайное булево значение.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool NextBoolean(this System.Random random) => random.Next(2) == 1;
    }
}