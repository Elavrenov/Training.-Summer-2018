using System;
using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    public class Task1Tests
    {
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindingRoots_RealNumbers(double number, int degree, double accuracy, double expected)
        {
            Assert.AreEqual(NewtonRoot.FindNthRoot(number, degree, accuracy), expected, accuracy);
        }

        [TestCase(-0.01, 2, 0.0001)]
        [TestCase(0.001, -2, 0.0001)]
        [TestCase(0.01, 2, -1)]
        public void FindingRoots_Throws_ArgumentExeption(double number, int degree, double accuracy)
        {
            Assert.Throws<ArgumentException>(() => NewtonRoot.FindNthRoot(number, degree, accuracy));
        }
    }
}
