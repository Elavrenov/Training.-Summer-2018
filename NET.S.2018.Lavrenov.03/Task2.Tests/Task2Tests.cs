using NUnit.Framework;


namespace Task2.Tests
{
    [TestFixture]
    public class Task2Tests
    {
        [TestCase(1071, 462, ExpectedResult = 21)]
        [TestCase(252, 105, ExpectedResult = 21)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        [TestCase(7920, 594, ExpectedResult = 198)]
        [TestCase(55, 15, 60, ExpectedResult = 5)]
        [TestCase(12, 24, 36, -42, ExpectedResult = 6)]
        public int EuclideanAlgorithm_Integers(params int[] numbers)
        {
            return GcdFinder.EuclideanAlgorithm(numbers);
        }

        [TestCase(1071, 462, ExpectedResult = 21)]
        [TestCase(252, 105, ExpectedResult = 21)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        [TestCase(7920, 594, ExpectedResult = 198)]
        [TestCase(55, 15, 60, ExpectedResult = 5)]
        [TestCase(12, 24, 36, -42, ExpectedResult = 6)]
        public int BinaryEuclideanAlgorithm_Integers(params int[] numbers)
        {
            return GcdFinder.BinaryEuclideanAlgorithm(numbers);
        }
    }
}
