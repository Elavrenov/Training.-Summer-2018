namespace BinarySearch.Tests
{
    using System.Collections.Generic;
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class BinarySearchTests
    {
        private readonly Comparison<int> _comparisonInt = (x, y) => x - y;
        private readonly Comparison<string> _comparisonString = (x, y) =>
        {
            if (x.Length > y.Length)
            {
                return 1;
            }

            if (x.Length < y.Length)
            {
                return -1;
            }

            if (x.Length == y.Length)
            {
                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] != y[i])
                    {
                        return 1;
                    }
                }
            }

            return 0;
        };

        [TestCase(new int[] { -1, 0, 1, 2, 3, 4, 5 }, 2, ExpectedResult = 3)]
        [TestCase(new int[] { -1, 0, 1, 2, 3, 4, 5 }, 5, ExpectedResult = 6)]
        [TestCase(new int[] { -1, 0, 1, 2, 3, 4, 5 }, -1, ExpectedResult = 0)]
        [TestCase(new int[] { -1, 0, 1, 2, 3, 4, 5 }, 0, ExpectedResult = 1)]
        [TestCase(new int[] { -1, 0, 1, 2, 3, 4, 5 }, 4, ExpectedResult = 5)]
        public int BinaryIntIComparerTest(int[] array, int item)
        {
            return BinarySearch.Search(array, item, Comparer<int>.Default);
        }

        [TestCase(new int[] { -1, 0, 1, 2, 3, 4, 5 }, 2, ExpectedResult = 3)]
        [TestCase(new int[] { -1, 0, 1, 2, 3, 4, 5 }, 5, ExpectedResult = 6)]
        [TestCase(new int[] { -1, 0, 1, 2, 3, 4, 5 }, -1, ExpectedResult = 0)]
        [TestCase(new int[] { -1, 0, 1, 2, 3, 4, 5 }, 0, ExpectedResult = 1)]
        [TestCase(new int[] { -1, 0, 1, 2, 3, 4, 5 }, 4, ExpectedResult = 5)]
        public int BinaryIntComparisonTest(int[] array, int item)
        {
            return BinarySearch.Search(array, item, _comparisonInt);
        }

        [TestCase(new int[] { -1, 0, 1, 2, 3, 4, 5 }, -2, ExpectedResult = -1)]
        [TestCase(new int[] { -1, 0, 1, 2, 3, 4, 5 }, 6, ExpectedResult = -1)]
        public int BinaryIntTestWrongArgs(int[] array, int item)
        {
            return BinarySearch.Search(array, item, _comparisonInt);
        }

        [TestCase(null, -2)]
        [TestCase(new int[] { }, -2)]
        public void BinarySearchIntsArgumentException(int[] array, int item)
        {
            Assert.Throws<ArgumentException>(() => BinarySearch.Search(array, item, _comparisonInt));
        }

        [TestCase(new[] { "m", "no", "ni", "word", "fffff", "IMMIDIATELY" }, "ni", ExpectedResult = 2)]
        [TestCase(new[] { "m", "no", "ni", "word", "fffff", "IMMIDIATELY" }, "m", ExpectedResult = 0)]
        [TestCase(new[] { "m", "no", "ni", "word", "fffff", "IMMIDIATELY" }, "IMMIDIATELY", ExpectedResult = 5)]
        [TestCase(new[] { "m", "no", "ni", "word", "fffff", "IMMIDIATELY" }, "no", ExpectedResult = 1)]
        public int BinaryStringTest(string[] array, string item)
        {
            return BinarySearch.Search(array, item, _comparisonString);
        }

        [TestCase(new[] { "m", "no", "ni", "word", "fffff", "IMMIDIATELY" }, "ny", ExpectedResult = -1)]
        [TestCase(new[] { "m", "no", "ni", "word", "fffff", "IMMIDIATELY" }, "mimix", ExpectedResult = -1)]
        [TestCase(new[] { "m", "no", "ni", "word", "fffff", "IMMIDIATELY" }, "IM", ExpectedResult = -1)]
        [TestCase(new[] { "m", "no", "ni", "word", "fffff", "IMMIDIATELY" }, "n1o", ExpectedResult = -1)]
        public int BinaryStringWrongArgsTest(string[] array, string item)
        {
            return BinarySearch.Search(array, item, _comparisonString);
        }

        [TestCase(new[] { "m", "no", "ni", "word", "fffff", "IMMIDIATELY" }, null)]
        [TestCase(null, "1")]
        [TestCase(new String[] { }, "1")]
        public void BinarySearchStringArgumentException(string[] array, string item)
        {
            Assert.Throws<ArgumentException>(() => BinarySearch.Search(array, item, _comparisonString));
        }
    }
}
