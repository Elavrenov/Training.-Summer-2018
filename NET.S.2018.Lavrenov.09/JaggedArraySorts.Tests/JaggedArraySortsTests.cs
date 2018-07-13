namespace JaggedArraySorts.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class JaggedArraySortsTests
    {
        [Test]
        public void InitializeArrayWithNull_ArgumentNullExeptionTest()
        {
            int[][] array = null;
            Assert.Throws<ArgumentNullException>(() => array.BubbleSort(new IncSumComparer()));
        }

        [Test]
        public void InitializeComparerWithNull_ArgumentNullExeptionTest()
        {
            int[][] actualArray = new int[][]
            {
                new int[] {1,22,0,3,-5,7,-9},
                new int[] {0,24,6,-5},
                null
            };

            Assert.Throws<ArgumentNullException>(() => actualArray.BubbleSort(null));
        }

        [Test]
        public void BubbleSort_IncreasingRowSumsTest()
        {
            int[][] actualArray = new int[][]
            {
                new int[] {1,22,0,3,-5,7,-9},
                new int[] {0,24,6,-5},
                null
            };

            int[][] expectedArray = new int[][]
            {
                null,
                new int[] {1,22,0,3,-5,7,-9},
                new int[] {0,24,6,-5}
            };

            actualArray.BubbleSort(new IncSumComparer());

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }
        [Test]
        public void BubbleSort_DecreasingRowSumsTest()
        {
            int[][] actualArray = new int[][]
            {
                new int[] {1,22,0,3,-5,7,-9},
                new int[] {0,24,6,-5},
                null
            };

            int[][] expectedArray = new int[][]
            {
                new int[] {0,24,6,-5},
                new int[] {1,22,0,3,-5,7,-9},
                null
            };

            actualArray.BubbleSort(new DecSumComparer());

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void BubbleSort_IncreasingMaxItemTest()
        {
            int[][] actualArray = new int[][]
            {
                new int[] {1,22,0,3,-5,7,-9},
                new int[] {0,24,6,-5},
                null
            };

            int[][] expectedArray = new int[][]
            {
                null,
                new int[] {1,22,0,3,-5,7,-9},
                new int[] {0,24,6,-5}
            };

            actualArray.BubbleSort(new IncMaxItemComparer());

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void BubbleSort_DecreasingMaxItemTest()
        {
            int[][] actualArray = new int[][]
            {
                new int[] {1,22,0,3,-5,7,-9},
                new int[] {0,24,6,-5},
                null
            };

            int[][] expectedArray = new int[][]
            {
                new int[] {0,24,6,-5},
                new int[] {1,22,0,3,-5,7,-9},
                null
            };

            actualArray.BubbleSort(new DecMaxItemComparer());

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void BubbleSort_IncreasingMinItemTest()
        {
            int[][] actualArray = new int[][]
            {
                new int[] {1,22,0,3,-5,7,-9},
                new int[] {0,24,6,-5},
                null
            };

            int[][] expectedArray = new int[][]
            {
                null,
                new int[] {1,22,0,3,-5,7,-9},
                new int[] {0,24,6,-5}
            };

            actualArray.BubbleSort(new IncMinItemComparer());

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void BubbleSort_DecreasingMinItemTest()
        {
            int[][] actualArray = new int[][]
            {
                new int[] {1,22,0,3,-5,7,-9},
                new int[] {0,24,6,-5},
                null
            };

            int[][] expectedArray = new int[][]
            {
                new int[] {0,24,6,-5},
                new int[] {1,22,0,3,-5,7,-9},
                null
            };

            actualArray.BubbleSort(new DecMinItemComparer());

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }
    }
}
