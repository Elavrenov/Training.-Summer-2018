using System.Linq.Expressions;

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
        public static AbstractSquareMatrix<T> Add<T>(this AbstractSquareMatrix<T> lhs, AbstractSquareMatrix<T> rhs)
        {
            if (lhs == null || rhs == null)
            {
                throw new ArgumentNullException($"{nameof(lhs)} and {nameof(rhs)} can't be null");
            }

            if (lhs.Order != rhs.Order)
            {
                throw new ArithmeticException($"Matrices has non-equal order");
            }

            var answer = new T[lhs.Order, lhs.Order];

            for (int i = 0; i < lhs.Order; i++)
            {
                for (int j = 0; j < lhs.Order; j++)
                {
                    answer[i, j] = AddFunc((dynamic)lhs[i, j], rhs[i, j]);
                }
            }

            return new SquareMatrix<T>(answer);
        }

        #region private methods

        private static T AddFunc<T>(T lhs, T rhs)
        {
            ParameterExpression paramLeft = Expression.Parameter(typeof(T), "lhs");
            ParameterExpression paramRight = Expression.Parameter(typeof(T), "rhs");
            BinaryExpression body = Expression.Add(paramLeft, paramRight);

            Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(body, paramLeft, paramRight).Compile();

            return add(lhs, rhs);
        }

        #endregion
    }
}
