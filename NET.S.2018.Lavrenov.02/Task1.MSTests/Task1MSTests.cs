using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.MSTests
{
    [TestClass]
    public class Task1MsTests
    {
        [TestMethod]
        public void InsertNumber_PositiveValues1_ChangingNumber()
        {
            int a = 15;
            int b = 15;
            int i = 0;
            int j = 0;

            int expected = 15;

            Assert.AreEqual(expected, BitChanger.InsertNumber(a, b, i, j));

        }

        [TestMethod]
        public void InsertNumber_PositiveValues2_ChangingNumber()
        {
            int a = 8;
            int b = 15;
            int i = 0;
            int j = 0;

            int expected = 9;

            Assert.AreEqual(expected, BitChanger.InsertNumber(a, b, i, j));

        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_NegativeValues1_ThrowArgumentOutOfRangeException()
        {
            int a = 8;
            int b = 15;
            int i = -3;
            int j = 8;

            int expected = 15;

            Assert.AreEqual(expected, BitChanger.InsertNumber(a, b, i, j));

        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_NegativeValues2_ThrowArgumentOutOfRangeException()
        {
            int a = 15;
            int b = 15;
            int i = 4;
            int j = -2;

            int expected = 15;

            Assert.AreEqual(expected, BitChanger.InsertNumber(a, b, i, j));

        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_NegativeValues3_ThrowArgumentOutOfRangeException()
        {
            int a = 15;
            int b = 15;
            int i = -4;
            int j = -2;

            int expected = 15;

            Assert.AreEqual(expected, BitChanger.InsertNumber(a, b, i, j));

        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_startGreaterThanEnd_ThrowArgumentException()
        {
            int a = 15;
            int b = 15;
            int i = 4;
            int j = 2;

            int expected = 15;

            Assert.AreEqual(expected, BitChanger.InsertNumber(a, b, i, j));
        }


    }
}
