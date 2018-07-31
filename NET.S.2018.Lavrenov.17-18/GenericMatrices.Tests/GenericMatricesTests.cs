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
            { 0,1,1,0},
            { 0,1,1,0},
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
        public void AdditionMatricesTests1()
        {
            SquareMatrix<int> lhs = new SquareMatrix<int>(_intArr1);
            DiagonalMatrix<int> rhs = new DiagonalMatrix<int>(_intArr2);

            int[,] expected = new int[,]
            {
                { 2,1,1,1},
                { 1,2,1,1},
                { 1,1,2,1},
                { 1,1,1,2}
            };

            CollectionAssert.AreEqual(new SquareMatrix<int>(expected), lhs.Add(rhs));
        }

        [TestCase(ExpectedResult = 1)]
        public int GetMatrixTest1()
        {
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(_intArr2);
            return squareMatrix[1, 1];
        }

        [TestCase(ExpectedResult = 0)]
        public int GetMatrixTest2()
        {
            SymmetricMatrix<int> sym = new SymmetricMatrix<int>(_intArr3);
            return sym[3, 3];
        }

        [Test]
        public void AdditionMatricesTests2()
        {
            SymmetricMatrix<int> lhs = new SymmetricMatrix<int>(_intArr3);
            DiagonalMatrix<int> rhs =new DiagonalMatrix<int>(_intArr2);

            int[,] expected = new int[,]
            {
                { 1,1,1,0},
                { 0,2,1,0},
                { 0,0,2,0},
                { 0,0,0,1}
            };

            CollectionAssert.AreEqual(new SquareMatrix<int>(expected), lhs.Add(rhs));
        }
    }
}
