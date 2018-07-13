namespace JaggedArraySorts
{
    using System.Collections.Generic;

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
            if (x is null && y is null)
            {
                return 0;
            }

            if (x is null)
            {
                return -1;
            }

            if (y is null)
            {
                return 1;
            }

            if (x.MinElement() > y.MinElement())
            {
                return 1;
            }

            if (x.MinElement() < y.MinElement())
            {
                return -1;
            }

            return 0;
        }
    }
}
