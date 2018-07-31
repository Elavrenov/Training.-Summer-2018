namespace GenericMatrices
{
    using System.Collections;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Base square matrix class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractSquareMatrix<T> : IEnumerable<T>
    {
        #region const

        private const int DefaultMaxtixSize = 3;

        #endregion

        #region Fields and prop

        private readonly T[,] _matrix;
        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;
        public int Order => _matrix.GetLength(0);

        #endregion

        #region Ctors

        protected AbstractSquareMatrix()
        {
            _matrix = new T[DefaultMaxtixSize, DefaultMaxtixSize];
        }
        protected AbstractSquareMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"{nameof(size)} of matrix can't be less or equals zero");
            }

            _matrix = new T[size, size];
        }

        protected AbstractSquareMatrix(T[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException($"{nameof(matrix)} can't be null");
            }

            if (matrix.GetLength(0) !=  matrix.GetLength(1))
            {
                throw new ArgumentException($"{nameof(matrix)} is not square");
            }

            _matrix = new T[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < _matrix.GetLength(1); i++)
            {
                for (int j = 0; j < _matrix.GetLength(0); j++)
                {
                    _matrix[i, j] = matrix[i, j];
                }
            }
        }

        #endregion

        #region Indexer

        public T this[int i, int j]
        {
            get
            {
                if (i < _matrix.GetLength(0) && j < _matrix.GetLength(1))
                {
                    if (!IsValidIndexes(i, j) || i == j)
                    {
                        return this.GetValue(i,j);
                    }
                }

                throw new ArgumentOutOfRangeException($"{nameof(i)},{nameof(j)} wrong indexes");
            }

            set
            {
                if (i < _matrix.GetLength(0) && j < _matrix.GetLength(1))
                {
                    if (!IsValidIndexes(i, j) || i == j)
                    {
                        var oldValue = _matrix[i, j];
                        SetValue(value,i,j);
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

        #region Abstract methods

        protected abstract T GetValue(int i,int j);
        protected abstract void SetValue(T value,int i,int j);

        #endregion

        #region Proctected virtual methods

        protected virtual void OnElementChanged(object sender, ElementChangedEventArgs<T> e)
        {
            EventHandler<ElementChangedEventArgs<T>> temp = this.ElementChanged;
            temp?.Invoke(sender, e);
        }

        protected virtual bool IsValidMatrixType() => _matrix.GetLength(0) == _matrix.GetLength(1);

        #endregion

        #region IEnumerable<T>

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    yield return _matrix[i, j];
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
