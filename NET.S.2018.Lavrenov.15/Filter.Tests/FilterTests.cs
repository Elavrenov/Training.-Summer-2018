namespace Filter.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class FilterTests
    {
        [TestCase(new[] { 1, 2, 3, 4, 0, -1, -1 - 2 }, ExpectedResult = new[] { 1, 2, 3, 4 })]
        [TestCase(new[] { -1, -2, 3, 4, 0, -1, -1 - 2 }, ExpectedResult = new[] { 3, 4 })]
        [TestCase(new[] { 1, -12, 3, 4, 0, -1, -1 - 2 }, ExpectedResult = new[] { 1, 3, 4 })]
        [TestCase(new[] { 1, 22, 3, 4, 0, -1, -1 - 2 }, ExpectedResult = new[] { 1, 22, 3, 4 })]
        [TestCase(new[] { 1, -11, 4, 0, -1, -1 - 2 }, ExpectedResult = new[] { 1, 4 })]

        public int[] FilterIntTest(int[] array)
        {
            return array.Filtration(x => x > 0);
        }

        [Test]
        public void FiterStringTest()
        {
            string[] actual = new[]
            {
                "Va44",
                "hello",
                "hell",
                "h",
                "razor",
                "nn"
            };

            string[] expected = new[]
            {
                "hello",
                "hell",
                "h",
            };

            CollectionAssert.AreEqual(expected, actual.Filtration(x => x.Contains("h")));
        }
    }
}
