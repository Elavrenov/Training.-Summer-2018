namespace GenericMatrices
{
    using System;

    /// <summary>
    /// Symmetric matrix class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class SymmetricMatrix<T> : SquareMatrix<T>
    {
        #region ctros

        public SymmetricMatrix(int size) : base(size)
        {

        }

        public SymmetricMatrix(T[,] matrix) : base(matrix)
        {
            if (!IsValidMatrixType())
            {
                throw new ArgumentException($"{nameof(matrix)} is not diagonal");
            }
        }

        #endregion

        #region Overrided methods

        protected override bool IsValidMatrixType()
        {
            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    if (!Equals(Matrix[i, j], Matrix[j, i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion


    }
}
