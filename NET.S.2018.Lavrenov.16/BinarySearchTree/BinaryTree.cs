namespace BinarySearchTree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Binary search tree class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T> : IEnumerable<T>
    {
        #region Fields

        /// <summary>
        /// main node(root)
        /// </summary>
        private BinaryNode<T> _root;


        /// <summary>
        /// comrarer
        /// </summary>
        private readonly IComparer<T> _comparer;

        #endregion

        #region Ctros

        /// <summary>
        /// base ctor
        /// </summary>
        public BinaryTree()
        {

        }

        /// <summary>
        /// ctor with 2 params
        /// </summary>
        /// <param name="collection">IEnumerable item</param>
        /// <param name="comparer">comparer</param>
        /// <exception cref="ArgumentNullException">comparer and collection can't be null</exception>
        public BinaryTree(IEnumerable<T> collection, IComparer<T> comparer)
        {
            if (collection == null)
            {
                throw new ArgumentNullException($"{nameof(collection)} can't be null");
            }

            _comparer = comparer ?? throw new ArgumentNullException($"{nameof(comparer)} can't be null");

            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public BinaryTree(IEnumerable<T> collection, Comparison<T> comparison) : this(collection, Comparer<T>.Create(comparison))
        {

        }

        public BinaryTree(IEnumerable<T> collection) : this(collection, Comparer<T>.Default)
        {

        }

        #endregion

        #region Public Api

        /// <summary>
        /// Insert value in to tree
        /// </summary>
        /// <param name="value">value</param>
        public void Add(T value)
        {
            var newNode = new BinaryNode<T>(value);

            if (_root == null)
            {
                _root = newNode;
                return;
            }

            #region Add

            void Add(BinaryNode<T> root, BinaryNode<T> node)
            {
                if (_comparer.Compare(node.Data, root.Data) <= 0)
                {
                    if (root.Left == null)
                    {
                        root.Left = node;
                    }
                    else
                    {
                        Add(root.Left, node);
                    }
                }
                else
                {
                    if (root.Right == null)
                    {
                        root.Right = node;
                    }
                    else
                    {
                        Add(root.Right, node);
                    }
                }
            }

            #endregion

            Add(_root, newNode);
        }

        /// <summary>
        /// returns true if tree contains value
        /// false in another way 
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>bool</returns>
        public bool Contains(T value)
        {
            #region Contains

            bool Contains(BinaryNode<T> node, T val)
            {
                if (node == null)
                {
                    return false;
                }

                var comparison = _comparer.Compare(val, node.Data);

                if (comparison == 0)
                {
                    return true;
                }

                if (comparison < 0)
                {
                    return Contains(node.Left, val);
                }

                return Contains(node.Right, val);
            }

            #endregion

            return Contains(_root, value);
        }

        /// <summary>
        /// minimal element in tree
        /// </summary>
        /// <returns></returns>
        public T GetMinimum()
        {
            if (_root == null)
            {
                return default(T);
            }

            var node = _root;

            while (node.Left != null)
            {
                node = node.Left;
            }

            return node.Data;
        }

        /// <summary>
        /// maximal element in tree
        /// </summary>
        /// <returns></returns>
        public T GetMaximum()
        {
            if (_root == null)
            {
                return default(T);
            }

            var node = _root;

            while (node.Right != null)
            {
                node = node.Right;
            }

            return node.Data;
        }

        #region IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #region Tree walks

        /// <summary>
        /// in order walks
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<T> InOrder()
        {
            return InOrder(_root);
        }

        /// <summary>
        /// pre order walks
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<T> PreOrder()
        {
            return PreOrder(_root);
        }

        /// <summary>
        /// ppost order walks
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<T> PostOrder()
        {
            return PostOrder(_root);
        }

        #endregion

        #endregion

        #endregion

        #region Private methods

        private IEnumerable<T> InOrder(BinaryNode<T> node)
        {
            while (true)
            {
                if (node == null)
                {
                    yield break;
                }

                if (node.Left != null)
                {
                    foreach (var item in InOrder(node.Left))
                    {
                        yield return item;
                    }
                }

                yield return node.Data;

                if (node.Right == null) yield break;
                {
                    node = node.Right;
                }
            }
        }

        private IEnumerable<T> PostOrder(BinaryNode<T> node)
        {
            if (node == null)
            {
                yield break;
            }

            if (node.Left != null)
            {
                foreach (var item in PostOrder(node.Left))
                {
                    yield return item;
                }
            }

            if (node.Right != null)
            {
                foreach (var item in PostOrder(node.Right))
                {
                    yield return item;
                }
            }

            yield return node.Data;
        }

        private IEnumerable<T> PreOrder(BinaryNode<T> node)
        {
            while (true)
            {
                if (node == null)
                {
                    yield break;
                }

                yield return node.Data;

                if (node.Left != null)
                {
                    foreach (var item in PreOrder(node.Left))
                    {
                        yield return item;
                    }
                }

                if (node.Right != null)
                {
                    node = node.Right;
                    continue;
                }

                break;
            }
        }

        #endregion

        /// <summary>
        /// class for tree node
        /// </summary>
        /// <typeparam name="T">all types</typeparam>
        private class BinaryNode<T>
        {
            public BinaryNode<T> Left { get; internal set; }
            public BinaryNode<T> Right { get; internal set; }
            public T Data { get; }

            public BinaryNode(T value)
            {
                Data = value;
                Left = null;
                Right = null;
            }
        }

    }


}
