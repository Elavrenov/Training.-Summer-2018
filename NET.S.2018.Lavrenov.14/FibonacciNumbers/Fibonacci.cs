namespace FibonacciNumbers
{
    using System;
    public static class Fibonacci
    {
        /// <summary>
        /// Method for searcing Fibonacci numbers
        /// </summary>
        /// <param name="amount">Digit of Fibonacci numbers</param>
        /// <returns>Array with fixed digit Fibonacci numbers</returns>
        /// <exception cref="ArgumentException">if <param name="amount"> less or equal zero</param></exception>
        public static int[] GetFibonacci(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException($"{amount} can't be less or equal zero");
            }

            int[] fibArray = new int[amount];
            fibArray[0] = 1;
            int a = 0;

            for (int i = 1; i < amount; i++)
            {

                int temp = fibArray[i - 1] + a;
                a = fibArray[i - 1];
                fibArray[i] = temp;
            }

            return fibArray;
        }
    }
}
