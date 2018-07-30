namespace GenericMatrices
{
    using System;

    /// <summary>
    /// Matrix extension class
    /// </summary>
    public static class MatrixExtension
    {
        /// <summary>
        /// If the matrices coincide in order, the method adds them up
        /// </summary>
        /// <typeparam name="T">all types</typeparam>
        /// <param name="lhs">left matrix</param>
        /// <param name="rhs">right matrix</param>
        /// <param name="addFunc">additional delegate</param>
        /// <returns>new square matrix which is sum of two matrices</returns>
        /// <exception cref="ArgumentException"><param name="lhs"><param name="rhs"> can't be null</param></param></exception>
        /// <exception cref="ArithmeticException">It's not possible to add 2 matrices with different dimmension</exception>
        public static SquareMatrix<T> Add<T>(this SquareMatrix<T> lhs, SquareMatrix<T> rhs, Func<T, T, T> addFunc)
        {
            if (lhs == null || rhs == null)
            {
                throw new ArgumentNullException($"{nameof(lhs)} and {nameof(rhs)} can't be null");
            }

            if (lhs.Order != rhs.Order)
            {
                throw new ArithmeticException($"Matrices has non-equal order");
            }

            var answer = new T[lhs.Order,lhs.Order];

            for (int i = 0; i < lhs.Order; i++)
            {
                for (int j = 0; j < lhs.Order; j++)
                {
                    answer[i, j] = addFunc(lhs[i, j], rhs[i, j]);
                }
            }

            return new SquareMatrix<T>(answer);
        }
    }
}
