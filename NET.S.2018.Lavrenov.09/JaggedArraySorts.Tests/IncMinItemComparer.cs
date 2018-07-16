namespace JaggedArraySorts.Tests
{
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Sealed conditional class with compare logic
    /// </summary>
    public sealed class IncMinItemComparer : IComparer<int[]>
    {
        /// <summary>
        /// Compares two arrays relative to the minimal element
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

            if (MinElement(x) > MinElement(y))
            {
                return 1;
            }

            if (MinElement(x) < MinElement(y))
            {
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// The method finds minimal array element
        /// </summary>
        /// <param name="array"> Array </param>
        /// <returns>Minimal element in given array</returns>
        /// <exception cref="ArgumentNullException">if array is null</exception>
        public static int MinElement(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be null");
            }

            int min = array[0];

            foreach (var item in array)
            {
                if (min > item)
                {
                    min = item;
                }
            }

            return min;
        }
    }
}
