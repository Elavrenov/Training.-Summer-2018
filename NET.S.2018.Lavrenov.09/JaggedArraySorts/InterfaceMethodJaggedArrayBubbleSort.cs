namespace JaggedArraySorts
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class for bubble sorting rows of jagged arrays with given comparision logic
    /// </summary>
    public static class InterfaceMethodJaggedArrayBubbleSort
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

            BubbleSort(array, condition.Compare);
        }

        #endregion

        #region Private methods

        private static void Swap(ref int[] firstRow, ref int[] secondRow)
        {
            int[] temp = firstRow;
            firstRow = secondRow;
            secondRow = temp;
        }

        private static void BubbleSort(int[][] array, Comparison<int[]> comparison)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                var isChanged = false;

                for (int j = 0; j < array.GetLength(0) - 1; j++)
                {
                    if (comparison(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        isChanged = true;
                    }
                }

                if (!isChanged)
                {
                    return;
                }
            }
        }

        #endregion
    }
}
