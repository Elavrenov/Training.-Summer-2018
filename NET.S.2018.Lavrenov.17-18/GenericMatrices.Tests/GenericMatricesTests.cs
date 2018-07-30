namespace GenericMatrices.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class GenericMatricesTests
    {
        private readonly int[,] _intArr1 = new int[,]
        {
            { 1,1,1,1},
            { 1,1,1,1},
            { 1,1,1,1},
            { 1,1,1,1}
        };

        private readonly int[,] _intArr2 = new int[,]
        {
            { 1,0,0,0},
            { 0,1,0,0},
            { 0,0,1,0},
            { 0,0,0,1}
        };
        private readonly int[,] _intArr3 = new int[,]
        {
            { 0,1,1,0},
            { 1,1,1,1},
            { 1,1,1,1},
            { 0,1,1,0}
        };

        private readonly int[,] _intArr4 = new int[,]
        {
            { 0,1,1,0},
            { 1,1,1,1},
            { 1,1,1,1},
            { 3,1,1,5}
        };

        [Test]
        public void ExceptionsIntMatrixTests()
        {
            Assert.Throws<ArgumentException>(() => new SquareMatrix<int>(-1));
            Assert.Throws<ArgumentException>(() => new DiagonalMatrix<int>(-1));
            Assert.Throws<ArgumentException>(() => new SymmetricMatrix<int>(-1));
            Assert.Throws<ArgumentException>(() => new DiagonalMatrix<int>(_intArr3));
            Assert.Throws<ArgumentException>(() => new SymmetricMatrix<int>(_intArr4));
        }

        [Test]
        public void CtorTests()
        {
            SymmetricMatrix<int> sym = new SymmetricMatrix<int>(_intArr3);
            DiagonalMatrix<int> dim = new DiagonalMatrix<int>(_intArr2);
            Assert.Pass();
        }

        [Test]
        public void AdditionMatricesTests()
        {
            SquareMatrix<int> lhs = new SquareMatrix<int>(_intArr1);
            DiagonalMatrix<int> rhs = new DiagonalMatrix<int>(_intArr2);

            int[,] expected1 = new int[,]
            {
                { 2,1,1,1},
                { 1,2,1,1},
                { 1,1,2,1},
                { 1,1,1,2}
            };

            int[,] expected2 = new int[,]
            {
                { 0,1,1,1},
                { 1,0,1,1},
                { 1,1,0,1},
                { 1,1,1,0}
            };

            CollectionAssert.AreEqual(new SquareMatrix<int>(expected1), lhs.Add(rhs, (x, y) => x + y));
            CollectionAssert.AreEqual(new SquareMatrix<int>(expected2), lhs.Add(rhs, (x, y) => x - y));
        }
    }
}
