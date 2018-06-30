using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerExtenshion
{
    /// <summary>
    /// Class for sorting int arrays
    /// </summary>
    public static class QuickSort
    {
        #region Public API

        /// <summary>
        /// The method for quick sort
        /// </summary>
        /// <param name="sortingArray">array for sorting</param>
        public static void Sort(int[] sortingArray)
        {
            IsValidArray(sortingArray);
            QuickSortHelper(sortingArray, 0, sortingArray.Length - 1);
        }

        /// <summary>
        /// Check sorted array
        /// </summary>
        /// <param name="array">checking array</param>
        /// <returns></returns>
        public static bool IsDecreasing(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] < array[++i])
                {
                    continue;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Private API

        /// <summary>
        /// The method for quick sort (or part of it)
        /// </summary>
        /// <param name="sortingArray">array for sorting</param>
        /// <param name="startIndex">start index for start sorting</param>
        /// <param name="endIndex">end index for sorting</param>
        public static void Sort(int[] sortingArray, int startIndex, int endIndex)
        {
            IsValidArray(sortingArray);

            if (startIndex >= endIndex || startIndex < 0 || endIndex < 0)
            {
                throw new ArgumentException("Wrong indexes");
            }

            QuickSortHelper(sortingArray, startIndex, endIndex - 1);
        }

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
