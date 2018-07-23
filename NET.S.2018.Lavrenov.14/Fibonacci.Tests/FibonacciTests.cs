namespace Fibonacci.Tests
{
    using System.Linq;
    using System.Numerics;
    using System;
    using NUnit.Framework;

    using FibonacciNumbers;
    [TestFixture]
    public class FibonacciTests
    {
        public void FibonacciNumbersTest()
        {
            BigInteger[][] expected =
            {
                new BigInteger[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 },
                new BigInteger[] { 0, 1, 1, 2, 3, 5, 8, 13 },
                new BigInteger[] { 0, 1 },
                new BigInteger[] { 0 }
            };

            int[] lenghts = new[] { 10, 8, 2, 1 };

            for (int i = 0; i < lenghts.Length; i++)
            {
                CollectionAssert.Equals(expected[i], Fibonacci.GetFibonacci(lenghts[i]));
            }
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-5)]
        public void FibonacciNumbersTestArgumentException(int n)
        {
            Assert.Throws<ArgumentException>(() => Fibonacci.GetFibonacci(n));
        }

        [TestCase(500, ExpectedResult = 500)]
        [TestCase(1500, ExpectedResult = 1500)]
        [TestCase(2500, ExpectedResult = 2500)]
        [TestCase(3500, ExpectedResult = 3500)]
        public int BigIntegerGenerateTest(int n)
        {
            return Fibonacci.GetFibonacci(n).ToArray().Length;
        }
    }
}
