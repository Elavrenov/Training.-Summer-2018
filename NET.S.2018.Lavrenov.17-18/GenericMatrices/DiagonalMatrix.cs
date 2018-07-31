using System;
namespace GenericMatrices
{
    public sealed class DiagonalMatrix<T> : AbstractSquareMatrix<T>
    {
        private readonly T[] _matrix;

        public DiagonalMatrix(int size):base(size)
        {
            _matrix = new T[size];
        }

        public DiagonalMatrix(T[,] matrix):base(matrix)
        {
            _matrix=new T[this.Order];

            for (int i = 0; i < Order; i++)
            {
                _matrix[i] = matrix[i, i];
            }
        }

        #region Overrided abstract methods

        protected override T GetValue(int i, int j)
        {
            return i == j ? _matrix[i] : default(T);
        }

        protected override void SetValue(T value, int i, int j)
        {
            if (i == j)
            {
                _matrix[i] = value;
            }
        }

        #endregion
    }
}
