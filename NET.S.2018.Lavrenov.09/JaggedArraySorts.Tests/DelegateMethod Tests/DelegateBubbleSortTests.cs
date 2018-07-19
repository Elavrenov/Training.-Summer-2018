using System;
using NUnit.Framework;

namespace JaggedArraySorts.Tests.Delegate
{
    [TestFixture]
    public class DelegateBubbleSortTests
    {
        [Test]
        public void InitializeArrayWithNull_ArgumentNullExeptionTest()
        {
            int[][] array = null;
            Assert.Throws<ArgumentNullException>(() => array.DelegateBubbleSort(new IncSumComparer().Compare));
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

            Assert.Throws<ArgumentNullException>(() => actualArray.DelegateBubbleSort(null));
        }

        [Test]
        public void DelegateBubbleSort_IncreasingRowSumsTest()
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

            actualArray.DelegateBubbleSort(new IncSumComparer().Compare);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void DelegateBubbleSort_DecreasingRowSumsTest()
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

            actualArray.DelegateBubbleSort(new DecSumComparer().Compare);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void DelegateBubbleSort_IncreasingMaxItemTest()
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

            actualArray.DelegateBubbleSort(new IncMaxItemComparer().Compare);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void DelegateBubbleSort_DecreasingMaxItemTest()
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

            actualArray.DelegateBubbleSort(new DecMaxItemComparer().Compare);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void DelegateBubbleSort_IncreasingMinItemTest()
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

            actualArray.DelegateBubbleSort(new IncMinItemComparer().Compare);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void DelegateBubbleSort_DecreasingMinItemTest()
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

            actualArray.DelegateBubbleSort(new DecMinItemComparer().Compare);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [Test]
        public void DelegateBubbleSort_DecreasingMinItemTestWithIntMaxValue()
        {
            int[][] actualArray = new int[][]
            {
                new int[] {1,22,0,3,-5,7,-9,int.MinValue},
                null,
                new int[] {0,24,6,-5,int.MaxValue}
            };

            int[][] expectedArray = new int[][]
            {
                new int[] {0,24,6,-5,int.MaxValue},
                new int[] {1,22,0,3,-5,7,-9,int.MinValue},
                null
            };

            actualArray.DelegateBubbleSort(new DecMinItemComparer().Compare);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }
    }
}
