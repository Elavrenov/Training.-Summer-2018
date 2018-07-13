namespace JaggedArraySorts
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class for bubble sorting rows of jagged arrays with given comparision logic
    /// </summary>
    public static class JaggedArrayBubbleSort
    {
        #region Public API

        /// <summary>
        /// Extension method for sorting jagged arrays
        /// with given comparision logic
        /// </summary>
        /// <param name="array"> Array for sorting </param>
        /// <param name="condition"> Necessary logic for sorting </param>
        /// <exception cref="ArgumentNullException">if given array is null</exception>
        /// <exception cref="ArgumentNullException">if given conddition is null</exception>
        public static void BubbleSort(this int[][] array, IComparer<int[]> condition)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be null");
            }

            if (condition is null)
            {
                throw new ArgumentNullException($"{nameof(condition)} can't be null");
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0) - 1; j++)
                {
                    if (condition.Compare(array[j], array[j + 1]) == 1)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// The method finds sum of array elements
        /// </summary>
        /// <param name="array"> Array </param>
        /// <returns>Sum of array elements</returns>
        /// <exception cref="ArgumentNullException">if array is null</exception>
        public static int RowSum(this int[] array)
        {
            if (array is null)
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

        /// <summary>
        /// The method finds maximal array element
        /// </summary>
        /// <param name="array"> Array </param>
        /// <returns>Maximal element in given array</returns>
        /// <exception cref="ArgumentNullException">if array is null</exception>
        public static int MaxElement(this int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be null");
            }

            int max = array[0];

            foreach (var item in array)
            {
                if (max < item)
                {
                    max = item;
                }
            }

            return max;
        }

        /// <summary>
        /// The method finds minimal array element
        /// </summary>
        /// <param name="array"> Array </param>
        /// <returns>Minimal element in given array</returns>
        /// <exception cref="ArgumentNullException">if array is null</exception>
        public static int MinElement(this int[] array)
        {
            if (array is null)
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

        #endregion

        #region Private API
        private static void Swap(ref int[] firstRow, ref int[] secondRow)
        {
            int[] temp = firstRow;
            firstRow = secondRow;
            secondRow = temp;
        }

        #endregion
    }
}
