namespace GenericQueue
{
    using System;
    using System.Collections.Generic;

    public class CustomQueue<T>
    {
        #region Fields and prop

        /// <summary>
        /// Instance for saving queue elements
        /// </summary>
        private T[] _queueArray;
        /// <summary>
        /// Queue head index
        /// </summary>
        private int _queueHead;
        /// <summary>
        /// Queue tail index
        /// </summary>
        private int _queueTail;
        /// <summary>
        /// Number of elements in queue
        /// </summary>
        private int _queueSize;

        /// <summary>
        /// Queue version
        /// </summary>
        public int Version { get; private set; }

        /// <summary>
        /// Prop for get number of elements in queue
        /// </summary>
        public int Count { get => _queueSize; }

        #endregion

        #region Ctors

        /// <summary>
        /// Default ctor
        /// </summary>
        public CustomQueue()
        {
            _queueArray = new T[4];
        }

        /// <summary>
        /// Ctor with given capacity
        /// </summary>
        /// <param name="capacity"></param>
        /// <exception cref="ArgumentException">capacity must be greater than zero</exception>
        public CustomQueue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException($"{nameof(capacity)} capacity must be greater than 0");
            }

            _queueArray = new T[capacity];
            _queueHead = 0;
            _queueTail = 0;
            _queueSize = 0;
        }

        /// <summary>
        /// Ctor initializing the queue with elements of some collection
        /// </summary>
        /// <param name="collection">IEnumerable item</param>
        /// <exception cref="ArgumentNullException">if collection is null</exception>
        public CustomQueue(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException($"{nameof(collection)} can't be null");
            }

            _queueArray = new T[4];
            _queueSize = 0;
            Version = 0;

            foreach (var item in collection)
            {
                this.Enqueue(item);
            }
        }

        #endregion

        #region Public API

        /// <summary>
        /// Determines whether an element is in the queue
        /// </summary>
        /// <param name="item">item</param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;

            foreach (var element in _queueArray)
            {
                if (equalityComparer.Equals(item, element))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Removes all objects from the queue
        /// </summary>
        public void Clear()
        {
            if (_queueHead < _queueTail)
            {
                Array.Clear(_queueArray, _queueHead, _queueSize);
            }
            else
            {
                Array.Clear(_queueArray, _queueHead, _queueArray.Length - _queueHead);
                Array.Clear(_queueArray, 0, _queueTail);
            }

            _queueSize = 0;
            _queueHead = 0;
            _queueTail = 0;
            ++Version;
        }

        /// <summary>
        /// Adds an object to the end of the queue
        /// </summary>
        /// <param name="item">item which need to add</param>
        public void Enqueue(T item)
        {
            if (_queueSize == _queueArray.Length)
            {
                SetCapacity(_queueArray.Length * 2);
            }

            _queueArray[_queueTail] = item;
            _queueTail = (_queueTail + 1) % _queueArray.Length;
            ++_queueSize;
            ++Version;
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the queue
        /// </summary>
        /// <returns>The object that is removed from the beginning of the queue</returns>
        /// <exception cref="ArgumentException">if queue size is 0</exception>
        public T Dequeque()
        {
            if (_queueSize == 0)
            {
                throw new ArgumentException($"Invalid operation: queue size is 0");
            }

            T item = _queueArray[_queueHead];
            _queueArray[_queueHead] = default(T);
            _queueHead = (_queueHead + 1) % _queueArray.Length;
            --_queueSize;
            ++Version;

            return item;
        }

        /// <summary>
        /// Returns the object at the beginning of the queue
        /// </summary>
        /// <returns>The object at the beginning of the queue</returns>
        /// <exception cref="ArgumentException">if queue size is 0</exception>
        public T Peek()
        {
            if (_queueSize == 0)
            {
                throw new ArgumentException($"Invalid operation: queue size is 0");
            }

            return _queueArray[_queueHead];
        }

        #region IEnumerable <T>

        public CustomIterator<T> GetEnumerator()
        {
            return new CustomIterator<T>(this);
        }

        #endregion

        #region Iterator

        public struct CustomIterator<T>
        {
            private readonly CustomQueue<T> _queue;
            private int _index;
            private readonly int _version;

            public CustomIterator(CustomQueue<T> queue)
            {
                _queue = queue;
                _index = queue._queueHead - 1;
                _version = _queue.Version;
            }

            public bool MoveNext()
            {
                if (_version != _queue.Version)
                {
                    throw new InvalidOperationException($"Wrong queue version");
                }

                return ++_index < _queue.Count;
            }

            public T Current
            {
                get
                {
                    if (_index == _queue._queueHead - 1 || _index == _queue.Count)
                    {
                        throw new InvalidOperationException($"Invalid operation");
                    }

                    return _queue._queueArray[_index];
                }
            }

            public void Reset()
            {
                if (_version != _queue.Version)
                {
                    throw new InvalidOperationException($"Wrong queue version");
                }

                _index = _queue._queueHead - 1;
            }
        }

        #endregion

        #endregion

        #region Private methods

        private bool IsEmpty => Count == 0;

        private void SetCapacity(int capacity)
        {
            T[] newQueueArray = new T[capacity];

            if (_queueHead < _queueTail)
            {
                Array.Copy(_queueArray, _queueHead, newQueueArray, 0, _queueSize);

            }
            else
            {
                Array.Copy(_queueArray, _queueHead, newQueueArray, 0, _queueArray.Length - _queueHead);
                Array.Copy(_queueArray, 0, newQueueArray, _queueArray.Length - _queueHead, _queueTail);
            }

            _queueArray = newQueueArray;
            _queueHead = 0;
            _queueTail = _queueSize == capacity ? 0 : _queueSize;
            ++Version;
        }

        #endregion

    }
}
