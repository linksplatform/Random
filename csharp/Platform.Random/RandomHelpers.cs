using System.Threading;

namespace Platform.Random
{
    /// <summary>
    /// <para>Contains factory methods and properties for <see cref="System.Random"/> class.</para>
    /// <para>Содержит фабричные методы и свойства для класса <see cref="System.Random"/>.</para>
    /// </summary>
    public static class RandomHelpers
    {
        private static readonly System.Lazy<System.Random> _default = new System.Lazy<System.Random>(() => new System.Random());
        
        private static readonly ThreadLocal<System.Random> _threadLocal = new ThreadLocal<System.Random>(() => new System.Random());

        /// <summary>
        /// <para>Returns the pseudorandom number generator that is using the time of the first access to this property as seed.</para>
        /// <para>Возвращает генератор псевдослучайных чисел использующий в качестве seed время первого обращения к этому свойству.</para>
        /// </summary>
        public static System.Random Default => _default.Value;

        /// <summary>
        /// <para>Returns a thread-local pseudorandom number generator that provides thread-safe access.</para>
        /// <para>Возвращает локальный для потока генератор псевдослучайных чисел, обеспечивающий потокобезопасный доступ.</para>
        /// </summary>
        public static System.Random ThreadLocal => _threadLocal.Value!;

        /// <summary>
        /// <para>Creates a new pseudorandom number generator using system time as seed.</para>
        /// <para>Создаёт новый генератор псевдослучайных чисел используя системное время в качестве seed.</para>
        /// </summary>
        /// <returns>
        /// <para>A new instance of <see cref="System.Random"/>.</para>
        /// <para>Новый экземпляр <see cref="System.Random"/>.</para>
        /// </returns>
        public static System.Random Create() => new System.Random();

        /// <summary>
        /// <para>Creates a new pseudorandom number generator using the specified seed value.</para>
        /// <para>Создаёт новый генератор псевдослучайных чисел используя указанное значение seed.</para>
        /// </summary>
        /// <param name="seed">
        /// <para>A number used to calculate a starting value for the pseudo-random number sequence.</para>
        /// <para>Число, используемое для вычисления начального значения последовательности псевдослучайных чисел.</para>
        /// </param>
        /// <returns>
        /// <para>A new instance of <see cref="System.Random"/>.</para>
        /// <para>Новый экземпляр <see cref="System.Random"/>.</para>
        /// </returns>
        public static System.Random Create(int seed) => new System.Random(seed);

        /// <summary>
        /// <para>Creates a cryptographically secure pseudorandom number generator.</para>
        /// <para>Создаёт криптографически стойкий генератор псевдослучайных чисел.</para>
        /// </summary>
        /// <returns>
        /// <para>A new instance of cryptographically secure random number generator.</para>
        /// <para>Новый экземпляр криптографически стойкого генератора случайных чисел.</para>
        /// </returns>
        public static System.Security.Cryptography.RandomNumberGenerator CreateSecure()
        {
#if NET6_0_OR_GREATER
            return System.Security.Cryptography.RandomNumberGenerator.Create();
#else
            return new System.Security.Cryptography.RNGCryptoServiceProvider();
#endif
        }
    }
}
