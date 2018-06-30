using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task6.MSTests
{
    [TestClass]
    public class Task6MsTests
    {
        [TestMethod]
        public void FilterDigit_PostiveArray_ChangedArray()
        {
            int[] expectedArray = new[] { 7, 7, 70, 17 };

            int[] actual = DigitExtenshion.FilterDigit(7, 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17);

            CollectionAssert.AreEquivalent(expectedArray, actual);
        }
        [TestMethod]
        public void FilterDigit_NegativeArray_ChangedArray()
        {
            int[] expectedArray = new[] { -7, -17 };

            int[] actual = DigitExtenshion.FilterDigit(-7, 7, 1, 2, 3, 4, 5, 6, -7, 68, 69, 70, 15, -17);

            CollectionAssert.AreEquivalent(expectedArray, actual);
        }

        [TestMethod, ExpectedException(typeof(NullReferenceException))]
        public void FilterDigit_ArrayWithNullReference_ThrowNullReferenceException()
        {
            int[] testArray = null;
            DigitExtenshion.FilterDigit(7,testArray);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void FilterDigit_ArrayWithWrongNumberOfElements_ThrowArgumentException()
        {
            int[] someArray = new[] { 5 };
            DigitExtenshion.FilterDigit(7,someArray);
        }
    }
}
