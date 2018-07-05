using System;
using System.Diagnostics;

namespace Task2
{
    /// <summary>
    /// Class for searching GCD(2 variants)
    /// </summary>
    public static class GcdFinder
    {
        #region Public API EuclideanGCD

        /// <summary>
        /// The method for searching GCD(Euclidian algorithm)
        /// 2 arguments
        /// </summary>
        /// <param name="firstNumber">first number</param>
        /// <param name="secondNumber">second number</param>
        /// <returns>GCD of 2 elements</returns>
        public static int EuclideanAlgorithm(int firstNumber, int secondNumber)
        {
            firstNumber = Math.Abs(firstNumber);
            secondNumber = Math.Abs(secondNumber);

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
        /// The method for searching GCD(Euclidian algorithm)
        /// 2 arguments
        /// </summary>
        /// <param name="elapsedTimeMiliSecs">algorithm working time</param>
        /// <param name="first">first element</param>
        /// <param name="second">second element</param>
        /// <returns>GCD of 2 elements and elapsed time in milliseconds</returns>
        public static int EuclideanAlgorithm(out long elapsedTimeMiliSecs, int first, int second)
        {
            Stopwatch timeWorking = new Stopwatch();
            timeWorking.Start();

            int gcd = EuclideanAlgorithm(first, second);

            timeWorking.Stop();

            elapsedTimeMiliSecs = timeWorking.Elapsed.Milliseconds;
            return gcd;
        }

        /// <summary>
        /// The method for searching GCD(Euclidian algorithm)
        /// 3 arguments
        /// </summary>
        /// <param name="first">first number</param>
        /// <param name="second">second number</param>
        /// <param name="third">third number</param>
        /// <returns>GCD of 3 elements</returns>
        public static int EuclideanAlgorithm(int first, int second, int third)
        {
            return EuclideanAlgorithm(EuclideanAlgorithm(first, second), third);
        }

        /// <summary>
        /// The method for searching GCD(Euclidian algorithm)
        /// 3 arguments
        /// </summary>
        /// <param name="elapsedTimeMiliSecs">algorithm working time</param>
        /// <param name="first">fist element</param>
        /// <param name="second">second element</param>
        /// <param name="third">third element</param>
        /// <returns>GCD of 3 elements and elapsed time in milliseconds</returns>
        public static int EuclideanAlgorithm(out long elapsedTimeMiliSecs, int first, int second, int third)
        {
            Stopwatch timeWorking = new Stopwatch();
            timeWorking.Start();

            int gcd = EuclideanAlgorithm(first, second, third);

            timeWorking.Stop();

            elapsedTimeMiliSecs = timeWorking.Elapsed.Milliseconds;
            return gcd;
        }

        /// <summary>
        /// The method for searching GCD(Euclidian algorithm)
        /// </summary>
        /// <param name="numbers"> integers </param>
        /// <returns> GCD of all numbers </returns>
        public static int EuclideanAlgorithm(params int[] numbers)
        {
            if (numbers.Length == 0 || numbers.Length == 1)
            {
                throw new ArgumentException($"{nameof(numbers)} must be greater than 1");
            }

            int answer = numbers[0];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                answer = EuclideanAlgorithm(answer, numbers[++i]);
            }

            return answer;
        }

        /// <summary>
        /// The method for searching GCD(Euclidian algorithm)
        /// </summary>
        /// <param name="elapsedTimeMiliSecs">algorithm working time</param>
        /// <param name="numbers">integers</param>
        /// <returns>GCD of all numbers and elapsed time in milliseconds</returns>
        public static int EuclideanAlgorithm(out long elapsedTimeMiliSecs, params int[] numbers)
        {
            Stopwatch timeWorking = new Stopwatch();
            timeWorking.Start();

            int gcd = EuclideanAlgorithm(numbers);

            timeWorking.Stop();

            elapsedTimeMiliSecs = timeWorking.Elapsed.Milliseconds;
            return gcd;
        }

        #endregion

        #region Public API BinaryGCD

        /// <summary>
        /// The method for searching GCD(Binary Euclidian algorithm)
        /// 2 arguments
        /// </summary>
        /// <param name="firstNumber">first number</param>
        /// <param name="secondNumber">second number</param>
        /// <returns>GCD of 2 elements</returns>
        public static int BinaryEuclideanAlgorithm(int firstNumber, int secondNumber)
        {
            firstNumber = Math.Abs(firstNumber);
            secondNumber = Math.Abs(secondNumber);

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
        /// <summary>
        /// The method for searching GCD(Binary Euclidian algorithm)
        /// 2 arguments
        /// </summary>
        /// <param name="elapsedTimeMiliSecs">algorithm working time</param>
        /// <param name="first">first element</param>
        /// <param name="second">second element</param>
        /// <returns>GCD of 2 elements and elapsed time in milliseconds</returns>
        public static int BinaryEuclideanAlgorithm(out long elapsedTimeMiliSecs, int first, int second)
        {
            Stopwatch timeWorking = new Stopwatch();
            timeWorking.Start();

            int gcd = BinaryEuclideanAlgorithm(first, second);

            timeWorking.Stop();

            elapsedTimeMiliSecs = timeWorking.Elapsed.Milliseconds;
            return gcd;
        }

        /// <summary>
        /// The method for searching GCD(Binary Euclidian algorithm)
        /// 3 arguments
        /// </summary>
        /// <param name="first">first number</param>
        /// <param name="second">second number</param>
        /// <param name="third">third number</param>
        /// <returns>GCD of 3 elements</returns>
        public static int BinaryEuclideanAlgorithm(int first, int second, int third)
        {
            return BinaryEuclideanAlgorithm(BinaryEuclideanAlgorithm(first, second), third);
        }

        /// <summary>
        /// The method for searching GCD(Binary Euclidian algorithm)
        /// 3 arguments
        /// </summary>
        /// <param name="elapsedTimeMiliSecs">algorithm working time</param>
        /// <param name="first">first element</param>
        /// <param name="second">second element</param>
        /// <param name="third">third element</param>
        /// <returns>GCD of 3 elements and elapsed time in milliseconds</returns>
        public static int BinaryEuclideanAlgorithm(out long elapsedTimeMiliSecs, int first, int second, int third)
        {
            Stopwatch timeWorking = new Stopwatch();
            timeWorking.Start();

            int gcd = BinaryEuclideanAlgorithm(first, second, third);

            timeWorking.Stop();

            elapsedTimeMiliSecs = timeWorking.Elapsed.Milliseconds;
            return gcd;
        }

        /// <summary>
        /// The method for searching GCD(Binary Euclidian algorithm)
        /// </summary>
        /// <param name="numbers">integers</param>
        /// <returns>GCD of all numbers</returns>
        public static int BinaryEuclideanAlgorithm(params int[] numbers)
        {
            if (numbers.Length == 0 || numbers.Length == 1)
            {
                throw new ArgumentException($"{nameof(numbers)} must be greater than 1");
            }

            int answer = numbers[0];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                answer = BinaryEuclideanAlgorithm(answer, numbers[++i]);
            }

            return answer;
        }

        /// <summary>
        /// The method for searching GCD(Binary Euclidian algorithm)
        /// </summary>
        /// <param name="elapsedTimeMiliSecs">algorithm working time</param>
        /// <param name="numbers">integers</param>
        /// <returns>GCD of all numbers and elapsed time in milliseconds</returns>
        public static int BinaryEuclideanAlgorithm(out long elapsedTimeMiliSecs, params int[] numbers)
        {
            Stopwatch timeWorking = new Stopwatch();
            timeWorking.Start();

            int gcd = BinaryEuclideanAlgorithm(numbers);

            timeWorking.Stop();

            elapsedTimeMiliSecs = timeWorking.Elapsed.Milliseconds;
            return gcd;
        }

        #endregion
    }
}