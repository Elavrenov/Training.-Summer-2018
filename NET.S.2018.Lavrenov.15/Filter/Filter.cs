namespace Filter
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Filter class
    /// </summary>
    public static class Filter
    {
        #region Public API

        /// <summary>
        /// Filter the array depending on the condition
        /// </summary>
        /// <typeparam name="T">All types</typeparam>
        /// <param name="array">T array</param>
        /// <param name="predicate">condition for filtration</param>
        /// <returns>Filtred array</returns>
        public static T[] Filtration<T>(this T[] array, Predicate<T> predicate)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be null");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} can't be null");
            }

            return StartFilter(array, predicate);
        }

        #endregion

        #region Private methods

        private static T[] StartFilter<T>(IEnumerable<T> enumerable, Predicate<T> predicate)
        {
            List<T> filtredList = new List<T>();

            foreach (var item in enumerable)
            {
                if (predicate(item))
                {
                    filtredList.Add(item);
                }
            }

            return filtredList.ToArray();
        }

        #endregion   
    }
}
