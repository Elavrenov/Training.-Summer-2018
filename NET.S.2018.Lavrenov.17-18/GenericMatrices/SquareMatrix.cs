using System.Collections.Generic;

namespace GenericMatrices
{
    public class SquareMatrix<T> : AbstractSquareMatrix<T>
    {
        private readonly T[] _matrix;

        public SquareMatrix(int size) : base(size)
        {
            _matrix = new T[size * size];
        }

        public SquareMatrix(T[,] matrix) : base(matrix)
        {
            _matrix = new T[this.Order * this.Order];

            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    _matrix[i * Order + j] = matrix[i, j];
                }
            }
        }

        #region Overrided abstract methods
        protected override T GetValue(int i, int j)
        {
            return _matrix[i * Order + j];
        }

        protected override void SetValue(T value, int i, int j)
        {
            _matrix[i * Order + j] = value;
        }

        #endregion


    }
}
