namespace GenericMatrices
{
    using System.Collections;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Base square matrix class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SquareMatrix<T> : IEnumerable<T>
    {
        #region const

        private const int DefaultMaxtixSize = 3;

        #endregion

        #region Fields and prop

        protected T[,] Matrix;
        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;
        public int Order => Matrix.GetLength(0);

        #endregion

        #region Ctors

        public SquareMatrix()
        {
            Matrix = new T[DefaultMaxtixSize, DefaultMaxtixSize];
        }
        public SquareMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"{nameof(size)} of matrix can't be less or equals zero");
            }

            Matrix = new T[size, size];
        }

        public SquareMatrix(T[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException($"{nameof(matrix)} can't be null");
            }

            Matrix = new T[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < Matrix.GetLength(1); i++)
            {
                for (int j = 0; j < Matrix.GetLength(0); j++)
                {
                    Matrix[i, j] = matrix[i, j];
                }
            }
        }

        #endregion

        #region Indexer

        public T this[int i, int j]
        {
            get
            {
                if (i < Matrix.GetLength(0) && j < Matrix.GetLength(1))
                {
                    if (!IsValidIndexes(i, j) || i == j)
                    {
                        var newMatrix = new T[Matrix.GetLength(0), Matrix.GetLength(1)];
                        Array.Copy(Matrix, newMatrix, Matrix.Length);
                        return newMatrix[i, j];
                    }
                }

                throw new ArgumentOutOfRangeException($"{nameof(i)},{nameof(j)} wrong indexes");
            }

            set
            {
                if (i < Matrix.GetLength(0) && j < Matrix.GetLength(1))
                {
                    if (!IsValidIndexes(i, j) || i == j)
                    {
                        var oldValue = Matrix[i, j];
                        Matrix[i, j] = value;
                        this.OnElementChanged(this, new ElementChangedEventArgs<T>(i, j, oldValue, value));
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"{nameof(i)},{nameof(j)} wrong indexes");
                }
            }
        }

        #endregion

        #region Proctected virtual methods

        protected virtual void OnElementChanged(object sender, ElementChangedEventArgs<T> e)
        {
            EventHandler<ElementChangedEventArgs<T>> temp = this.ElementChanged;
            temp?.Invoke(sender, e);
        }

        protected virtual bool IsValidMatrixType() => Matrix.GetLength(0) == Matrix.GetLength(1);

        #endregion

        #region IEnumerable<T>

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    yield return Matrix[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Private methods

        private bool IsValidIndexes(int i, int j)
        {
            if (i < 0)
            {
                throw new ArgumentException($"{nameof(i)} less than zero");
            }

            if (j < 0)
            {
                throw new ArgumentException($"{nameof(j)} less than zero");
            }

            if (i == j)
            {
                return true;
            }

            return false;
        }

        #endregion

    }
}
