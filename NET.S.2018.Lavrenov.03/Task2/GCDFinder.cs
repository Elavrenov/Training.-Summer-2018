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
            return GetEuclidianGcd(EuclidGcd, firstNumber, secondNumber);
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

            int gcd = GetEuclidianGcd(EuclidGcd, first, second);

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
            return GetEuclidianGcd(EuclidGcd, first, second, third);
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

            int gcd = GetEuclidianGcd(EuclidGcd, first, second, third);

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
            return GetEuclidianGcd(EuclidGcd, numbers);
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

            int gcd = GetEuclidianGcd(EuclidGcd, numbers);

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
            return GetSteinGcd(SteinGcd, firstNumber, secondNumber);
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

            int gcd = GetSteinGcd(SteinGcd, first, second);

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
            return GetSteinGcd(SteinGcd, first, second, third);
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

            int gcd = GetSteinGcd(SteinGcd, first, second, third);

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
            return GetSteinGcd(SteinGcd, numbers);
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

            int gcd = GetSteinGcd(SteinGcd, numbers);

            timeWorking.Stop();

            elapsedTimeMiliSecs = timeWorking.Elapsed.Milliseconds;
            return gcd;
        }

        #endregion

        #endregion

        #region PrivateMethods

        #region Private Euclidian methods

        private static int GetEuclidianGcd(Func<int, int, int> gcdFunc, int firstNumber, int secondNumber)
        {
            if (gcdFunc == null) throw new ArgumentNullException($"{nameof(gcdFunc)} can't be null");
            if (firstNumber == 0 && secondNumber == 0)
            {
                throw new ArgumentException($"Wrong parameters");
            }

            return gcdFunc(firstNumber, secondNumber);

        }

        private static int GetEuclidianGcd(Func<int, int, int> gcdFunc, int firstNumber, int secondNumber, int thirdNumber)
        {
            if (gcdFunc == null) throw new ArgumentNullException($"{nameof(gcdFunc)} can't be null");
            if (firstNumber == 0 && secondNumber == 0 && thirdNumber == 0)
            {
                throw new ArgumentException($"Wrong parameters");
            }

            return gcdFunc(gcdFunc(firstNumber, secondNumber), thirdNumber);
        }

        private static int GetEuclidianGcd(Func<int, int, int> gcdFunc, params int[] numbers)
        {
            if (gcdFunc == null) throw new ArgumentNullException($"{nameof(gcdFunc)} can't be null");


            if (numbers.Length == 0 || numbers.Length == 1)
            {
                throw new ArgumentException($"{nameof(numbers)} must be greater than 1");
            }

            int answer = numbers[0];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                answer = gcdFunc(answer, numbers[++i]);
            }

            return answer;
        }
        private static int EuclidGcd(int firstNumber, int secondNumber)
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

        #endregion

        #region Private Stein methods

        private static int GetSteinGcd(Func<int, int, int> gcdFunc, params int[] numbers)
        {
            if (numbers.Length == 0 || numbers.Length == 1)
            {
                throw new ArgumentException($"{nameof(numbers)} must be greater than 1");
            }

            int answer = numbers[0];
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                answer = gcdFunc(answer, numbers[++i]);
            }

            return answer;
        }

        private static int GetSteinGcd(Func<int, int, int> gcdFunc, int firstNumber, int secondNumber, int thirdNumber)
        {
            if (gcdFunc == null) throw new ArgumentNullException($"{nameof(gcdFunc)} can't be null");
            if (firstNumber == 0 && secondNumber == 0 && thirdNumber == 0)
            {
                throw new ArgumentException($"Wrong parameters");
            }

            return gcdFunc(gcdFunc(firstNumber, secondNumber), thirdNumber);
        }

        private static int GetSteinGcd(Func<int, int, int> gcdFunc, int firstNumber, int secondNumber)
        {
            if (gcdFunc == null) throw new ArgumentNullException($"{nameof(gcdFunc)} can't be null");
            if (firstNumber == 0 && secondNumber == 0)
            {
                throw new ArgumentException($"Wrong parameters");
            }

            return gcdFunc(firstNumber, secondNumber);
        }
        private static int SteinGcd(int firstNumber, int secondNumber)
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
                    return SteinGcd(firstNumber >> 1, secondNumber);
                }

                return SteinGcd(firstNumber >> 1, secondNumber >> 1) << 1;
            }

            if ((~secondNumber & 1) != 0)
            {
                return SteinGcd(firstNumber, secondNumber >> 1);
            }

            if (firstNumber > secondNumber)
            {
                return SteinGcd((firstNumber - secondNumber) >> 1, secondNumber);
            }

            return SteinGcd((secondNumber - firstNumber) >> 1, firstNumber);
        }

        #endregion

        #endregion
    }
}