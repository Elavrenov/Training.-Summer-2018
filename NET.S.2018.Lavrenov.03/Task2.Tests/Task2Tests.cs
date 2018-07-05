using NUnit.Framework;


namespace Task2.Tests
{
    [TestFixture]
    public class Task2Tests
    {
        [TestCase(7920, 594, ExpectedResult = 198)]
        [TestCase(1071, 462, ExpectedResult = 21)]
        [TestCase(252, 105, ExpectedResult = 21)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        public int EuclideanAlgorithm_Integers(int first, int second)
        {
            return GcdFinder.EuclideanAlgorithm(first, second);
        }

        [TestCase(44, 32, 553, ExpectedResult = 1)]
        [TestCase(55, 15, 60, ExpectedResult = 5)]
        public int EuclideanAlgorithm_Integers(int first, int second, int third)
        {
            return GcdFinder.EuclideanAlgorithm(first, second, third);
        }

        [TestCase(7920, 594, ExpectedResult = 198)]
        [TestCase(1071, 462, ExpectedResult = 21)]
        [TestCase(252, 105, ExpectedResult = 21)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        [TestCase(55, 15, 60, ExpectedResult = 5)]
        [TestCase(456, 123, 333, 55, ExpectedResult = 1)]
        [TestCase(12, 24, 36, -42, ExpectedResult = 6)]
        public int EuclideanAlgorithm_Integers(params int[] numbers)
        {
            return GcdFinder.EuclideanAlgorithm(numbers);
        }

        [TestCase(7920, 594, ExpectedResult = 198)]
        [TestCase(1071, 462, ExpectedResult = 21)]
        [TestCase(252, 105, ExpectedResult = 21)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        public int BinaryEuclideanAlgorithm_Integers(int first, int second)
        {
            return GcdFinder.BinaryEuclideanAlgorithm(first, second);
        }

        [TestCase(44, 32, 553, ExpectedResult = 1)]
        [TestCase(55, 15, 60, ExpectedResult = 5)]
        public int BinaryEuclideanAlgorithm_Integers(int first, int second, int third)
        {
            return GcdFinder.BinaryEuclideanAlgorithm(first, second, third);
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
