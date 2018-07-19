namespace JaggedArraySorts
{
    using System;
    using System.Collections.Generic;
    public static class DelegateMethodJaggedArrayBubbleSort
    {
        #region Public API

        /// <summary>
        /// Extension method for sorting jagged arrays
        /// with given comparision logic
        /// </summary>
        /// <param name="array"> Array for sorting </param>
        /// <param name="conditionFunc">Necessary logic for sorting</param>
        /// <exception cref="ArgumentNullException">if given array is null</exception>
        /// <exception cref="ArgumentNullException">if given conddition is null</exception>
        public static void DelegateBubbleSort(this int[][] array, Func<int[], int[], int> conditionFunc)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be null");
            }

            if (conditionFunc is null)
            {
                throw new ArgumentNullException($"{nameof(conditionFunc)} can't be null");
            }

            BubbleSort(array, new Decorator(conditionFunc));
        }

        #endregion

        #region Private methods

        private static void Swap(ref int[] firstRow, ref int[] secondRow)
        {
            int[] temp = firstRow;
            firstRow = secondRow;
            secondRow = temp;
        }

        private static void BubbleSort(int[][] array, IComparer<int[]> comparer)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                var isChanged = false;

                for (int j = 0; j < array.GetLength(0) - 1; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
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

        #region Class decorator

        /// <summary>
        /// Class decorator
        /// </summary>
        public class Decorator : IComparer<int[]>
        {
            private readonly Func<int[], int[], int> _conditionFunc;

            public Decorator(Func<int[], int[], int> conditionFunc)
            {
                _conditionFunc = conditionFunc;
            }
            public int Compare(int[] x, int[] y)
            {
                return _conditionFunc(x, y);
            }
        }

        #endregion

    }
}
