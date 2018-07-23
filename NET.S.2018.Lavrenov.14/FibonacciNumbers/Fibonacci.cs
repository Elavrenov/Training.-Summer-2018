namespace FibonacciNumbers
{
    using System.Collections.Generic;
    using System.Numerics;
    using System;
    public static class Fibonacci
    {
        #region Public API

        /// <summary>
        /// Method for searcing Fibonacci numbers
        /// </summary>
        /// <param name="amount">Digit of Fibonacci numbers</param>
        /// <returns> IEnumerable BigInteger with fixed digit Fibonacci numbers</returns>
        /// <exception cref="ArgumentException">if <param name="amount"> less or equal zero</param></exception>
        public static IEnumerable<BigInteger> GetFibonacci(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException($"{amount} can't be less or equals zero");
            }

            return FibonacciGenerator(amount);
        }

        #endregion

        #region Private methods

        private static IEnumerable<BigInteger> FibonacciGenerator(int n)
        {
            BigInteger current = 0;
            BigInteger next = 1;

            for (int i = 0; i < n; i++)
            {
                yield return current;

                BigInteger temp = current + next;
                current = next;
                next = temp;
            }
        }

        #endregion
    }
}
