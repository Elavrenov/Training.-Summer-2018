using System;
namespace GenericMatrices
{
    public sealed class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix(int size) : base(size)
        {
            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    if (i != j)
                    {
                        Matrix[i, j] = default(T);
                    }
                }
            }
        }

        public DiagonalMatrix(T[,] matrix) : base(matrix)
        {
            if (!IsValidMatrixType())
            {
                throw new ArgumentException($"{nameof(matrix)} is not diagonal");
            }
        }
        protected override bool IsValidMatrixType()
        {
            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    if (i != j)
                    {
                        if (!Equals(Matrix[i, j], default(T)))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
