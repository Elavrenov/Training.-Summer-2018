using System;
using NUnit.Framework;

namespace Task6.MSTests
{
    [TestFixture]
    class Task6NUnitTests
    {
        [TestCase(new int[] {7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17}, 7)]
        public void FilterDigit_PostiveArray_ChangedArray(ref int[] someArray,int digit)
        {
            int[] expectedArray = new[] { 7, 7, 70, 17 };
            DigitExtenshion.FilterDigit(ref someArray, 7);
            CollectionAssert.AreEqual(expectedArray, someArray);
        }

        [TestCase(new int[] { 7, 1, 2, 3, 4, 5, 6, -7, 68, 69, 70, 15, -17 },-7)]
        public void FilterDigit_NegativeArray_ChangedArray(ref int[] someArray, int digit)
        {
            int[] expectedArray = new[] { -7, -17 };
            DigitExtenshion.FilterDigit(ref someArray, -7);
            CollectionAssert.AreEqual(expectedArray, someArray);
        }

        [Test]
        public void FilterDigit_ArrayWithNullReference_ThrowNullReferenceException()
        {
            int[] someArray = null;
            Assert.Throws<NullReferenceException>(()=>DigitExtenshion.FilterDigit(ref someArray, 7));
        }

        [Test]
        public void ArrayWithWrongNumberOfElements_ThrowArgumentException()
        {
            int[] someArray = new[] {5};
            Assert.Throws<ArgumentException>(() => DigitExtenshion.FilterDigit(ref someArray, 24));
        }
    }
}
