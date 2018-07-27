namespace BinarySearchTree.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class BinarySearchTreeTests
    {
        [TestCase(new[] { 5, 4, 3, 1, 9, 8, 6, 7, 15, 10 }, ExpectedResult = new[] { 1, 3, 4, 5, 6, 7, 8, 9, 10, 15 })]
        public IEnumerable<int> InOrderIntTest(int[] actual)
        {
            return new BinaryTree<int>(actual).InOrder();
        }

        [TestCase(new[] { 5, 4, 3, 1, 9, 8, 6, 7, 15, 10 }, ExpectedResult = new[] { 5, 4, 3, 1, 9, 8, 6, 7, 15, 10 })]
        public IEnumerable<int> PreOrderIntTest(int[] actual)
        {
            return new BinaryTree<int>(actual).PreOrder();
        }

        [TestCase(new[] { 5, 4, 3, 1, 9, 8, 6, 7, 15, 10 }, ExpectedResult = new[] { 1, 3, 4, 7, 6, 8, 10, 15, 9, 5 })]
        public IEnumerable<int> PostOrderIntTest(int[] actual)
        {
            return new BinaryTree<int>(actual).PostOrder();
        }


        [TestCase(new[] { 5, 4, 3, 1, 9, 8, 6, 7, 15, 10 }, ExpectedResult = new[] { 5, 4, 3, 1, 9, 8, 6, 7, 15, 10 })]
        public IEnumerable<int> InOrderIntTestDelegate(int[] actual)
        {
            var tree = new BinaryTree<int>(actual, (x, y) => x + y);
            return tree.InOrder();
        }

        [TestCase(new[] { 5, 4, 3, 1, 9, 8, 6, 7, 15, 10 }, ExpectedResult = new[] { 5, 4, 3, 1, 9, 8, 6, 7, 15, 10 })]
        public IEnumerable<int> PreOrderIntTestDelegate(int[] actual)
        {
            var tree = new BinaryTree<int>(actual, (x, y) => x + y);
            return tree.PreOrder();
        }

        [TestCase(new[] { 5, 4, 3, 1, 9, 8, 6, 7, 15, 10 }, ExpectedResult = new[] { 10, 15, 7, 6, 8, 9, 1, 3, 4, 5 })]
        public IEnumerable<int> PostOrderIntTestDelegate(int[] actual)
        {
            var tree = new BinaryTree<int>(actual, (x, y) => x + y);
            return tree.PostOrder();
        }

        [TestCase(new[] { 5, 4, 3, 1, 9, 8, 6, 7, 15, 10 })]
        public void ContainsIntTest(int[] actual)
        {
            var tree = new BinaryTree<int>(actual);

            Assert.True(tree.Contains(4));
            Assert.True(tree.Contains(9));
            Assert.True(tree.Contains(1));
            Assert.True(tree.Contains(6));
        }

        [TestCase(new[] { "g", "f", "c", "d", "i", "l", "m" }, "", ExpectedResult = new[] { "c", "d", "f", "g", "i", "l", "m" })]
        public IEnumerable<string> InOrderStringTest(string[] actual, string s)
        {
            return new BinaryTree<string>(actual).InOrder();
        }

        [TestCase(new[] { "g", "f", "c", "d", "i", "l", "m" }, "", ExpectedResult = new[] { "g", "f", "c", "d", "i", "l", "m" })]
        public IEnumerable<string> PreOrderStringTest(string[] actual, string s)
        {
            return new BinaryTree<string>(actual).PreOrder();
        }

        [TestCase(new[] { "g", "f", "c", "d", "i", "l", "m" }, "", ExpectedResult = new[] { "d", "c", "f", "m", "l", "i", "g" })]
        public IEnumerable<string> PostOrderStringTest(string[] actual, string s)
        {
            return new BinaryTree<string>(actual).PostOrder();
        }

        [TestCase(new[] { "g", "f", "c", "d", "i", "l", "m" }, "")]
        public void ContainsStringTest(string[] actual, string s)
        {
            var tree = new BinaryTree<string>(actual);

            Assert.True(tree.Contains("g"));
            Assert.True(tree.Contains("f"));
            Assert.True(tree.Contains("i"));
            Assert.True(tree.Contains("m"));
        }

        private static Book b1 = new Book();
        private static Book b2 = new Book();
        private static Book b3 = new Book();

        [Test]
        public void InOrderBookTest()
        {
            b1.Heigth = 100;
            b2.Heigth = 101;
            b3.Heigth = 102;

            IEnumerable<Book> expected = new[] { b1, b2, b3 };

            var tree = new BinaryTree<Book>(new[] { b2, b1, b3 });

            CollectionAssert.AreEqual(expected, tree.InOrder());
        }

        [Test]
        public void PreOrderBookTest()
        {
            b1.Heigth = 100;
            b2.Heigth = 101;
            b3.Heigth = 102;

            IEnumerable<Book> expected = new[] { b2, b1, b3 };

            var tree = new BinaryTree<Book>(new[] { b2, b1, b3 });

            CollectionAssert.AreEqual(expected, tree.PreOrder());
        }

        [Test]
        public void PostOrderBookTest()
        {
            b1.Heigth = 100;
            b2.Heigth = 101;
            b3.Heigth = 102;

            IEnumerable<Book> expected = new[] { b1, b3, b2 };

            var tree = new BinaryTree<Book>(new[] { b2, b1, b3 });

            CollectionAssert.AreEqual(expected, tree.PostOrder());
        }

        private static Point p1 = new Point(4, 4);
        private static Point p2 = new Point(0, 1);
        private static Point p3 = new Point(-1, -1);

        [Test]
        public void InOrderPointTest()
        {
            IEnumerable<Point> expected = new[] { p3, p2, p1 };

            var tree = new BinaryTree<Point>(new[] { p2, p1, p3 }, (x, y) => x.X - y.X);

            CollectionAssert.AreEqual(expected, tree.InOrder());
        }

        [Test]
        public void PreOrderPointTest()
        {
            IEnumerable<Point> expected = new[] { p2, p3, p1 };

            var tree = new BinaryTree<Point>(new[] { p2, p1, p3 }, (x, y) => x.X - y.X);

            CollectionAssert.AreEqual(expected, tree.PreOrder());
        }

        [Test]
        public void PostOrderPointTest()
        {
            IEnumerable<Point> expected = new[] { p3, p1, p2 };

            var tree = new BinaryTree<Point>(new[] { p2, p1, p3 }, (x, y) => x.X - y.X);

            CollectionAssert.AreEqual(expected, tree.PostOrder());
        }
    }
}
