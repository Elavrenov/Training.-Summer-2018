using System;
using IntegerExtenshion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegerExtension.Tests
{
    [TestClass]
    public class SortsTests
    {
        [TestMethod]
        public void MergeSort_Integers()
        {
            int[] testArray = new[] { 3, 2, 1, 0, -5, 4, 4, 5 };
            int[] expected = new[] { -5, 0, 1, 2, 3, 4, 4, 5 };

            MergeSort.Sort(testArray);

            CollectionAssert.AreEqual(expected, testArray);
        }

        [TestMethod]
        public void MergeSort_ALotOfIntegers()
        {
            Random random = new Random();
            int[] testArray = new int[1000000];

            for (int i = 0; i < testArray.Length; i++)
            {
                testArray[i] = random.Next(-1000000, 1000000);
            }

            MergeSort.Sort(testArray);

            Assert.IsFalse(!MergeSort.IsDecreasing(testArray));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_NullReferense_ThrowsArgumentNullExeption()
        {
            int[] testArray = null;
            MergeSort.Sort(testArray);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void MergeSort_LenghtZero_ThrowsArgumentExeption()
        {
            int[] testArray = new int[0];
            MergeSort.Sort(testArray);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void MergeSort_LenghtOne_ThrowsArgumentExeption()
        {
            int[] testArray = new int[1];
            MergeSort.Sort(testArray);
        }

        [TestMethod]
        public void QuickSort_Integers()
        {
            int[] testArray = new[] { 3, 2, 1, 0, -5, 4, 4, 5 };
            int[] expected = new[] { -5, 0, 1, 2, 3, 4, 4, 5 };

            QuickSort.Sort(testArray);

            CollectionAssert.AreEqual(expected, testArray);
        }

        [TestMethod]
        public void QuickSort_ALotOfIntegers()
        {
            Random random = new Random();
            int[] testArray = new int[1000000];

            for (int i = 0; i < testArray.Length; i++)
            {
                testArray[i] = random.Next(-1000000, 1000000);
            }

            QuickSort.Sort(testArray);

            Assert.IsFalse(!MergeSort.IsDecreasing(testArray));
        }


        [TestMethod]
        public void QuickSortOverload_Integers()
        {
            int[] testArray = new[] { 3, 2, 1, 0, -5, 4, 4, 5 };
            int[] expected = new[] { 3, -5, 0, 1, 2, 4, 4, 5 };

            QuickSort.Sort(testArray, 1, 5);

            CollectionAssert.AreEqual(expected, testArray);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_NullReferense_ThrowsArgumentNullExeption()
        {
            int[] testArray = null;
            QuickSort.Sort(testArray);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void QuickSort_LenghtZero_ThrowsArgumentExeption()
        {
            int[] testArray = new int[0];
            QuickSort.Sort(testArray);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void QuickSort_LenghtOne_ThrowsArgumentExeption()
        {
            int[] testArray = new int[1];
            QuickSort.Sort(testArray);
        }


    }
}
