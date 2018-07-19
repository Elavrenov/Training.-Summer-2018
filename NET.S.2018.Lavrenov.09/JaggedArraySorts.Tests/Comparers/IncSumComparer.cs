namespace JaggedArraySorts.Tests
{
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Sealed conditional class with compare logic
    /// </summary>
    public sealed class IncSumComparer : IComparer<int[]>
    {
        /// <summary>
        /// Compares two arrays relative to the elements sum
        /// </summary>
        /// <param name="x">First compared array</param>
        /// <param name="y">Second compared array</param>
        /// <returns>
        /// 0 if two arrays are null
        /// 1 if first array is null
        /// -1 if second array is null
        /// 1 if the first array is larger by comparison logic
        /// -1 if the first array is less by comparison logic
        /// </returns>
        public int Compare(int[] x, int[] y)
        {
            if (x == null && y == null)
            {
                return 0;
            }

            if (x == null)
            {
                return -1;
            }

            if (y == null)
            {
                return 1;
            }

            if (RowSum(x) > RowSum(y))
            {
                return 1;
            }

            if (RowSum(x) < RowSum(y))
            {
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// The method finds sum of array elements
        /// </summary>
        /// <param name="array"> Array </param>
        /// <returns>Sum of array elements</returns>
        /// <exception cref="ArgumentNullException">if array is null</exception>
        public static int RowSum(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be null");
            }

            int sum = 0;

            foreach (var item in array)
            {
                sum += item;
            }

            return sum;
        }
    }
}
