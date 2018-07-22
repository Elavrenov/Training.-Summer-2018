namespace Fibonacci.Tests
{
    using System;
    using NUnit.Framework;

    using FibonacciNumbers;
    [TestFixture]
    public class FibonacciTests
    {
        [TestCase(10, ExpectedResult = new int[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 })]
        [TestCase(1, ExpectedResult = new int[] { 1 })]
        [TestCase(5, ExpectedResult = new int[] { 1, 1, 2, 3, 5 })]
        public int[] FibonacciNumbersTest(int n)
        {
            return Fibonacci.GetFibonacci(n);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-5)]
        public void FibonacciNumbersTestArgumentException(int n)
        {
            Assert.Throws<ArgumentException>(() => Fibonacci.GetFibonacci(n));
        }
    }
}
