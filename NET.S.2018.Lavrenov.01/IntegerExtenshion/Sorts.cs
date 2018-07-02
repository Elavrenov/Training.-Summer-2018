using System;

namespace IntegerExtenshion
{
    /// <summary>
    /// Class for sorting int arrays
    /// </summary>
    public static class Sorts
    {
        #region Public API

        /// <summary>
        /// The method returns a sorted array
        /// </summary>
        /// <param name="arrayForSorting">Array for sorting</param>
        public static void MergeSort(int[] arrayForSorting)
        {
            IsValidArray(arrayForSorting);
            MergeSortHelper(arrayForSorting, 0, arrayForSorting.Length);
        }

        /// <summary>
        /// The method for quick sort
        /// </summary>
        /// <param name="sortingArray">array for sorting</param>
        /// <exception cref="ArgumentNullException">does not exist reference or null</exception>
        /// <exception cref="ArgumentException">array has no lenght</exception>
        /// <exception cref="ArgumentException">array has lenght equals 1</exception>
        public static void QuickSort(int[] sortingArray)
        {
            IsValidArray(sortingArray);
            QuickSortHelper(sortingArray, 0, sortingArray.Length - 1);
        }

        #endregion

        #region Private API

        /// <summary>
        /// The method checks the validity of the data
        /// </summary>
        /// <param name="sortingArray">Verifiable array</param>
        private static void IsValidArray(int[] sortingArray)
        {
            if (sortingArray == null)
            {
                throw new ArgumentNullException(nameof(sortingArray));
            }

            if (sortingArray.Length == 0)
            {
                throw new ArgumentException(nameof(sortingArray));
            }

            if (sortingArray.Length == 1)
            {
                throw new ArgumentException(nameof(sortingArray));
            }
        }

        /// <summary>
        /// Merge helper method for creating sub arrays
        /// </summary>
        /// <param name="arrayForSorting"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        private static void MergeSortHelper(int[] arrayForSorting, int startIndex, int endIndex)
        {
            var leftSubMas = new int[endIndex / 2];
            var rightSubMas = new int[endIndex - leftSubMas.Length];
            Array.Copy(arrayForSorting, leftSubMas, leftSubMas.Length);
            Array.Copy(arrayForSorting, leftSubMas.Length, rightSubMas, startIndex, rightSubMas.Length);
            if (leftSubMas.Length > 1)
            {
                MergeSortHelper(leftSubMas, 0, leftSubMas.Length);
            }

            if (rightSubMas.Length > 1)
            {
                MergeSortHelper(rightSubMas, 0, rightSubMas.Length);
            }

            MegreSubMas(arrayForSorting, leftSubMas, rightSubMas);
        }

        /// <summary>
        /// Method for sorting sub arrays
        /// </summary>
        /// <param name="subArray">array for sorting</param>
        /// <param name="leftMas"> left sub array</param>
        /// <param name="rightMas">right sub array</param>
        private static void MegreSubMas(int[] subArray, int[] leftMas, int[] rightMas)
        {
            int leftIndex = 0, rightIndex = 0;
            for (var i = 0; i < subArray.Length; i++)
            {
                MergeIndexHelper(leftMas, rightMas, subArray, ref leftIndex, ref rightIndex, i);
            }
        }

        /// <summary>
        /// The helper method for indexing
        /// </summary>
        /// <param name="leftMas">first array</param>
        /// <param name="rightMas">second array</param>
        /// <param name="tempMas"> copying array</param>
        /// <param name="leftIndex">minimal index</param>
        /// <param name="rightIndex">maximal index</param>
        /// <param name="i">index</param>
        private static void MergeIndexHelper(int[] leftMas, int[] rightMas, int[] tempMas, ref int leftIndex,
            ref int rightIndex, int i)
        {
            if (rightIndex >= rightMas.Length)
            {
                tempMas[i] = leftMas[leftIndex];
                leftIndex++;
            }
            else if (leftIndex < leftMas.Length && leftMas[leftIndex] < rightMas[rightIndex])
            {
                tempMas[i] = leftMas[leftIndex];
                leftIndex++;
            }
            else
            {
                tempMas[i] = rightMas[rightIndex];
                rightIndex++;
            }
        }

        /// <summary>
        /// The method for swap two elements
        /// </summary>
        /// <param name="firstElement">first element for swap</param>
        /// <param name="secondElement">second element for swap</param>
        private static void Swap(ref int firstElement, ref int secondElement)
        {
            int temp;
            temp = firstElement;
            firstElement = secondElement;
            secondElement = temp;
        }

        /// <summary>
        /// Recursion method for sorting subarrays
        /// </summary>
        /// <param name="subArray">base subarray</param>
        /// <param name="firstIndex">first index for swap</param>
        /// <param name="lastIndex">last index for swap</param>
        private static void QuickSortHelper(int[] subArray, int firstIndex, int lastIndex)
        {
            int startIndex = firstIndex;
            int endIndex = lastIndex;
            int baseElement = subArray[(firstIndex + lastIndex) / 2];

            while (startIndex <= endIndex)
            {
                while (subArray[startIndex] < baseElement)
                {
                    startIndex++;
                }

                while (subArray[endIndex] > baseElement)
                {
                    endIndex--;
                }

                if (startIndex <= endIndex)
                {
                    Swap(ref subArray[startIndex++], ref subArray[endIndex--]);
                }

            }

            if (firstIndex < endIndex)
            {
                QuickSortHelper(subArray, firstIndex, endIndex);
            }

            if (lastIndex > startIndex)
            {
                QuickSortHelper(subArray, startIndex, lastIndex);
            }
        }

        #endregion
    }
}