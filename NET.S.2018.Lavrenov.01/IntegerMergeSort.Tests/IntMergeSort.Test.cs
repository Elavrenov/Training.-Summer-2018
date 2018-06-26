using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegerMergeSort.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IntQuickSort_ArrayWasSorted()
        {
            int[] someArray = new[] { 3, 2, 1, 0, -5, 4, 4, 5 };
            int[] expected = new[] { -5, 0, 1, 2, 3, 4, 4, 5 };

            int[] actual=IntMergeSort.SortInts(someArray);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(NullReferenceException))]
        public void IntQuickSort_ArrayWithNullReference_ThrowNullReferenceException()
        {
            int[] someArray = null;
            IntMergeSort.IsValidArray(someArray);

        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void IntQuickSort_ArrayWithNullArgumenr_ThrowNoNullAllowedException()
        {
            int[] someArray = new int[0];
            IntMergeSort.IsValidArray(someArray);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void IntQuickSort_ArrayWithNoSize_ThrowArgumentException()
        {
            int[] someArray = new int[1];
            IntMergeSort.IsValidArray(someArray);
        }
    }
}
