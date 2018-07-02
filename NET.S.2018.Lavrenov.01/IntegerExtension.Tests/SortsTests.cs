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

            Sorts.MergeSort(testArray);

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

            Sorts.MergeSort(testArray);

            Assert.IsFalse(IsDecreasing(testArray));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_NullReferense_ThrowsArgumentNullExeption()
        {
            int[] testArray = null;
            Sorts.MergeSort(testArray);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void MergeSort_LenghtZero_ThrowsArgumentExeption()
        {
            int[] testArray = new int[0];
            Sorts.MergeSort(testArray);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void MergeSort_LenghtOne_ThrowsArgumentExeption()
        {
            int[] testArray = new int[1];
            Sorts.MergeSort(testArray);
        }

        [TestMethod]
        public void QuickSort_Integers()
        {
            int[] testArray = new[] { 3, 2, 1, 0, -5, 4, 4, 5 };
            int[] expected = new[] { -5, 0, 1, 2, 3, 4, 4, 5 };

            Sorts.QuickSort(testArray);

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

            Sorts.QuickSort(testArray);

            Assert.IsFalse(IsDecreasing(testArray));
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_NullReferense_ThrowsArgumentNullExeption()
        {
            int[] testArray = null;
            Sorts.QuickSort(testArray);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void QuickSort_LenghtZero_ThrowsArgumentExeption()
        {
            int[] testArray = new int[0];
            Sorts.QuickSort(testArray);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void QuickSort_LenghtOne_ThrowsArgumentExeption()
        {
            int[] testArray = new int[1];
            Sorts.QuickSort(testArray);
        }

        /// <summary>
        /// Check sorted array
        /// </summary>
        /// <param name="array">checking array</param>
        /// <returns></returns>
        private static bool IsDecreasing(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[++i])
                {
                    break;
                }
            }

            return false;
        }
    }
}
