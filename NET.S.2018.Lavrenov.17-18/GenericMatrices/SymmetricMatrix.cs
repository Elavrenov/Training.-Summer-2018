namespace GenericMatrices
{
    using System;

    /// <summary>
    /// Symmetric matrix class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class SymmetricMatrix<T> : AbstractSquareMatrix<T>
    {
        private readonly T[] _matrix;


        #region ctros

        public SymmetricMatrix(int size) : base(size)
        {
            _matrix = new T[(size * size - size) / 2 + size];
        }

        public SymmetricMatrix(T[,] matrix) : base(matrix)
        {
            _matrix = new T[(Order * Order - Order) / 2 + Order];

            int k = 0;

            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j + i < Order; j++)
                {
                    _matrix[k++] = matrix[i, j + i];
                }
            }
        }
        #endregion

        #region Overrided abstract methods

        protected override T GetValue(int i, int j)
        {
            if (i == 0 || j == 0)
            {
                return _matrix[i + j];
            }

            return _matrix[i + j + 1];
        }

        protected override void SetValue(T value, int i, int j)
        {
            if (i == 0 || j == 0)
            {
                _matrix[j + i] = value;
            }
            else
            {
                _matrix[i + j + 1] = value;
            }
        }

        #endregion

    }
}
