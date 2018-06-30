using System;
using NUnit.Framework;

namespace Task6.MSTests
{
    [TestFixture]
    class Task6NUnitTests
    {
        [TestCase(7, new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, ExpectedResult = new int[] { 7, 7, 70, 17 })]
        public int[] FilterDigit_PostiveArray_ChangedArray(int digit, params int[] testArray)
        {
            return DigitExtenshion.FilterDigit(7, testArray);
        }

        [TestCase(-7, new int[] { 7, 1, 2, 3, 4, 5, 6, -7, 68, 69, 70, 15, -17 }, ExpectedResult = new int[] { -7, -17 })]
        public int[] FilterDigit_NegativeArray_ChangedArray(int digit, params int[] testArray)
        {
            return DigitExtenshion.FilterDigit(-7,testArray);
        }

        [Test]
        public void FilterDigit_ArrayWithNullReference_ThrowNullReferenceException()
        {
            int[] testArray = null;
            Assert.Throws<NullReferenceException>(() => DigitExtenshion.FilterDigit(7,testArray));
        }

        [Test]
        public void ArrayWithWrongNumberOfElements_ThrowArgumentException()
        {
            int[] testArray = new[] { 5 };
            Assert.Throws<ArgumentException>(() => DigitExtenshion.FilterDigit(24,testArray));
        }
    }
}
