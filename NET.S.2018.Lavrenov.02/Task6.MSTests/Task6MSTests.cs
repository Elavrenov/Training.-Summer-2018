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
            int[] someArray = new[] {7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17};
            int[] expectedArray = new []{7, 7, 70, 17};

            DigitExtenshion.FilterDigit(ref someArray,7);

            CollectionAssert.AreEquivalent(expectedArray,someArray);
        }
        [TestMethod]
        public void FilterDigit_NegativeArray_ChangedArray()
        {
            int[] someArray = new[] { 7, 1, 2, 3, 4, 5, 6, -7, 68, 69, 70, 15, -17 };
            int[] expectedArray = new[] { -7,-17 };

            DigitExtenshion.FilterDigit(ref someArray, -7);

            CollectionAssert.AreEquivalent(expectedArray, someArray);
        }

        [TestMethod, ExpectedException(typeof(NullReferenceException))]
        public void FilterDigit_ArrayWithNullReference_ThrowNullReferenceException()
        {
            int[] someArray = null;
            DigitExtenshion.FilterDigit(ref someArray, 7);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void FilterDigit_ArrayWithWrongNumberOfElements_ThrowArgumentException()
        {
            int[] someArray = new[] {5};
            DigitExtenshion.FilterDigit(ref someArray, 7);
        }
    }
}
