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
    public static class MergeSort
    {
        #region Public API

        /// <summary>
        /// The method returns a sorted array
        /// </summary>
        /// <param name="arrayForSorting">Array for sorting</param>
        /// <returns></returns>
        public static void Sort(int[] arrayForSorting)
        {
            IsValidArray(arrayForSorting);
            MergeSortHelper(arrayForSorting, 0, arrayForSorting.Length);
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

        #endregion
    }
}
