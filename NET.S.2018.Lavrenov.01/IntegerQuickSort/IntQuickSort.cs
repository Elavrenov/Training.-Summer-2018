using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerQuickSort
{
    /// <summary>
    /// Class for quick sorting
    /// </summary>
    public static class IntQuickSort
    {
        /// <summary>
        /// The method checks the validity of the data
        /// </summary>
        /// <param name="sortingArray">Verifiable array</param>
        /// <returns></returns>
        public static bool IsValidArray(int[] sortingArray)
        {
            if (sortingArray == null)
            {
                throw new NullReferenceException(nameof(sortingArray));
            }

            if (sortingArray.Length==0)
            {
                throw new ArgumentException(nameof(sortingArray));
            }

            if (sortingArray.Length==1)
            {
                throw new ArgumentException(nameof(sortingArray));
            }
            return true;
        }
        /// <summary>
        /// The method for swap wto elements in base array
        /// </summary>
        /// <param name="array">base array</param>
        /// <param name="firstElement">first element for swap</param>
        /// <param name="secondElement">second element for swap</param>
        private static void Swap(int[] array, int firstElement, int secondElement)
        {
            int temp;
            temp = array[firstElement];
            array[firstElement] = array[secondElement];
            array[secondElement] = temp;
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
            int baseIndex = subArray[(firstIndex + lastIndex) / 2];

            while (startIndex <= endIndex)
            {
                while (subArray[startIndex] < baseIndex)
                {
                    startIndex++;
                }

                while (subArray[endIndex] > baseIndex)
                {
                    endIndex--;
                }

                if (startIndex <= endIndex)
                {
                    Swap(subArray, startIndex++, endIndex--);
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
        /// <summary>
        /// The method for quick sort
        /// </summary>
        /// <param name="sortingArray">array for sorting</param>
        public static void QuickSort(int[] sortingArray)
        {
            if (IsValidArray(sortingArray))
            {
                int firstIndex = 0;
                int lastIndex = sortingArray.Length - 1;
                QuickSortHelper(sortingArray, firstIndex, lastIndex);
            }
        }
    }
}
