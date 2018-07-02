using System;
using System.Diagnostics;

namespace Task2
{
    /// <summary>
    /// Class for searching GCD(2 variants)
    /// </summary>
    public static class GcdFinder
    {
        #region Public API

        /// <summary>
        /// The method for searching GCD(Euclidian algorithm)
        /// </summary>
        /// <param name="numbers">integers</param>
        /// <returns></returns>
        public static int EuclideanAlgorithm(params int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Math.Abs(numbers[i]);
            }

            int answer = numbers[0];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                answer = EuclideanAlgorithm(answer, numbers[++i]);
            }

            return answer;
        }

        /// <summary>
        /// The method for searching GCD(Binary Euclidian algorithm)
        /// </summary>
        /// <param name="numbers">integers</param>
        /// <returns></returns>
        public static int BinaryEuclideanAlgorithm(params int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Math.Abs(numbers[i]);
            }

            int answer = numbers[0];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                answer = BinaryEuclideanAlgorithm(answer, numbers[++i]);
            }

            return answer;
        }
        public static TimeSpan GetTimeEuclidianMethod(params int[] numbers)
        {
            Stopwatch timeWorking = new Stopwatch();
            timeWorking.Start();

            EuclideanAlgorithm(numbers);

            timeWorking.Stop();

            return timeWorking.Elapsed;
        }

        public static TimeSpan GetTimeBinaryEuclidianMethod(params int[] numbers)
        {
            Stopwatch timeWorking = new Stopwatch();
            timeWorking.Start();

            BinaryEuclideanAlgorithm(numbers);

            timeWorking.Stop();

            return timeWorking.Elapsed;
        }
        #endregion

        #region Private API

        /// <summary>
        /// The method for searching GCD(Euclidian algorithm)
        /// 2 arguments
        /// </summary>
        /// <param name="firstNumber">first number</param>
        /// <param name="secondNumber">second number</param>
        /// <returns></returns>
        private static int EuclideanAlgorithm(int firstNumber, int secondNumber)
        {
            while (firstNumber != secondNumber)
            {
                if (firstNumber > secondNumber)
                {
                    firstNumber = firstNumber - secondNumber;
                }
                else
                {
                    secondNumber = secondNumber - firstNumber;
                }
            }
            return firstNumber;
        }

        /// <summary>
        /// The method for searching GCD(Binary Euclidian algorithm)
        /// 2 arguments
        /// </summary>
        /// <param name="firstNumber">first number</param>
        /// <param name="secondNumber">second number</param>
        /// <returns></returns>
        private static int BinaryEuclideanAlgorithm(int firstNumber, int secondNumber)
        {
            if (firstNumber == secondNumber)
            {
                return firstNumber;
            }

            if (firstNumber == 0)
            {
                return secondNumber;
            }

            if (secondNumber == 0)
            {
                return firstNumber;
            }

            if ((~firstNumber & 1) != 0)
            {
                if ((secondNumber & 1) != 0)
                {
                    return BinaryEuclideanAlgorithm(firstNumber >> 1, secondNumber);
                }

                return BinaryEuclideanAlgorithm(firstNumber >> 1, secondNumber >> 1) << 1;
            }

            if ((~secondNumber & 1) != 0)
            {
                return BinaryEuclideanAlgorithm(firstNumber, secondNumber >> 1);
            }

            if (firstNumber > secondNumber)
            {
                return BinaryEuclideanAlgorithm((firstNumber - secondNumber) >> 1, secondNumber);
            }

            return BinaryEuclideanAlgorithm((secondNumber - firstNumber) >> 1, firstNumber);
        }

        #endregion
    }
}