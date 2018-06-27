using System;
using NUnit.Framework;

namespace Task1.MSTests
{   
    [TestFixture]
    class Task1NUnitTests
    {
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        public int InsertNumber_PositiveValues_ChangingNumber(int a, int b, int i, int j)
        {
            return BitChanger.InsertNumber(a, b, i, j);
        }

        [Test]
        public void InsertNumber_NegativeValues1_ThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => BitChanger.InsertNumber(8, 15, -3, 8));
        }

        [Test]
        public void InsertNumber_NegativeValues2_ThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => BitChanger.InsertNumber(15, 15, 4, -2));
        }

        [Test]
        public void InsertNumber_NegativeValues3_ThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => BitChanger.InsertNumber(15, 15, -4, -2));
        }

        [Test]
        public void InsertNumber_TestIndexOverFlow()
        {
            Assert.Throws<ArgumentException>(() => BitChanger.InsertNumber(15, 15, 4, 2));
        }
    }
}
