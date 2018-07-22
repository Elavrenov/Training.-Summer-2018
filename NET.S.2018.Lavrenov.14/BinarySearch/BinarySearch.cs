namespace BinarySearch
{
    using System;

    /// <summary>
    /// Class for finding an element in a sorted array, 
    /// which uses the fragmentation of the array into halves.
    /// </summary>
    public static class BinarySearch
    {
        #region Public API

        /// <summary>
        /// algorithm for finding an element in a sorted array,
        /// which uses the fragmentation of the array into halves.
        /// </summary>
        /// <typeparam name="T">All types</typeparam>
        /// <param name="array">Array in which we finding</param>
        /// <param name="item">Item which need to find</param>
        /// <param name="comparison">Comparison</param>
        /// <returns>Index of item</returns>
        /// <exception cref="ArgumentException">if <param name="array"> is null</param></exception>
        /// <exception cref="ArgumentException">if <param name="comparison"> is null</param></exception>
        /// <exception cref="ArgumentException">if <param name="array"> length is zero</param></exception>
        /// <exception cref="ArgumentException">if <param name="item"> is null</param></exception>
        /// <exception cref="ArgumentException">if <param name="item"> is absent in array</param></exception>
        public static int Search<T>(T[] array, T item, Comparison<T> comparison)
        {
            if (array == null)
            {
                throw new ArgumentException($"{nameof(array)} array can't be null");
            }

            if (comparison == null)
            {
                throw new ArgumentException($"{nameof(comparison)} can't be null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} length is 0");
            }

            if (item == null)
            {
                throw new ArgumentException($"{nameof(item)} item can't be null");
            }

            return SearchHelper(array, item, comparison);
        }

        #endregion
        
        #region Private methods

        private static int SearchHelper<T>(T[] array, T item, Comparison<T> comparison)
        {
            int first = 0;
            int last = array.Length;

            if (comparison(array[0], item) > 0)
            {
                throw new ArgumentException($"{nameof(item)} is absent in array");
            }

            if (comparison(array[array.Length - 1], item) < 0)
            {
                throw new ArgumentException($"{nameof(item)} is absent in array");
            }

            while (first < last)
            {
                int mid = first + (last - first) / 2;

                if (comparison(item, array[mid]) <= 0)
                {
                    last = mid;
                }
                else
                {
                    first = mid + 1;
                }
            }

            if (comparison(array[last], item) == 0)
            {
                return last;
            }

            throw new ArgumentException($"{nameof(item)} is absent in array");
        }

        #endregion
    }

}
