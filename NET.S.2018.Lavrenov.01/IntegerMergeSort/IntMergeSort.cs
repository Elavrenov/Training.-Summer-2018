using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerMergeSort
{
    /// <summary>
    /// Class for merge sorting
    /// </summary>
    public static class IntMergeSort
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

            if (sortingArray.Length == 0)
            {
                throw new ArgumentException(nameof(sortingArray));
            }

            if (sortingArray.Length == 1)
            {
                throw new ArgumentException(nameof(sortingArray));
            }
            return true;
        }
        /// <summary>
        /// The method returns a sorted array
        /// </summary>
        /// <param name="arrayForSorting">Array for sorting</param>
        /// <returns></returns>
        public static int[] SortInts(int[] arrayForSorting)
        {
            if (IsValidArray(arrayForSorting))
            {
            var leftSubMas = new int[arrayForSorting.Length / 2];
            var rightSubMas = new int[arrayForSorting.Length - leftSubMas.Length];

            Array.Copy(arrayForSorting, leftSubMas, leftSubMas.Length);
            Array.Copy(arrayForSorting, leftSubMas.Length, rightSubMas, 0, rightSubMas.Length);

            if (leftSubMas.Length > 1)
            {
                leftSubMas = SortInts(leftSubMas);
            }

            if (rightSubMas.Length > 1)
            {
                rightSubMas = SortInts(rightSubMas);
            }

            arrayForSorting = MegreSubMas(leftSubMas, rightSubMas);
            }
            return arrayForSorting;
        }

        /// <summary>
        /// The method returns a sorted sub arrays
        /// </summary>
        /// <param name="leftMas">irst array</param>
        /// <param name="rightMas">second array</param>
        /// <returns></returns>
        private static int[] MegreSubMas(int[] leftMas, int[] rightMas)
        {
            var tempMas = new int[leftMas.Length + rightMas.Length];
            int leftIndex = 0, rightIndex = 0;
            for (var i = 0; i < tempMas.Length; i++)
            {
                MergeHelper(leftMas, rightMas, tempMas, ref leftIndex, ref rightIndex, i);
            }
            return tempMas;
        }
        /// <summary>
        /// The helper-method for indexing
        /// </summary>
        /// <param name="leftMas">first array</param>
        /// <param name="rightMas">second array</param>
        /// <param name="tempMas"> copying array</param>
        /// <param name="leftIndex">minimal index</param>
        /// <param name="rightIndex">maximal index</param>
        /// <param name="i">index</param>
        private static void MergeHelper(int[] leftMas, int[] rightMas, int[] tempMas, ref int leftIndex, ref int rightIndex, int i)
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
    }
}
