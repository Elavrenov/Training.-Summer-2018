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
            _matrix = new T[size * size];
        }

        public SymmetricMatrix(T[,] matrix) : base(matrix)
        {
            _matrix = new T[Order * Order];

            for (int i = 0; i < Order; i++)
            {
                for (int j = i; j < Order; j++)
                {
                    _matrix[GetIndex(i, j)] = matrix[i, j];
                }
            }
        }
        #endregion

        #region Overrided abstract methods

        protected override T GetValue(int i, int j)
        {
            return _matrix[GetIndex(i, j)];
        }

        protected override void SetValue(T value, int i, int j)
        {
            _matrix[GetIndex(i, j)] = value;
        }

        #endregion

        #region Private method

        private int GetIndex(int i, int j)
        {
            int index = 0;
            for (int k = 0; k < Order; k++)
            {
                for (int z = k; z < Order; z++)
                {
                    if ((i == k) && (j == z))
                    {
                        return index;
                    }

                    index++;
                }
            }

            return index;
        }

    }

    #endregion
}

