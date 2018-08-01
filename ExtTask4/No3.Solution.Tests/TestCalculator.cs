using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace No3.Solution.Tests
{
    [TestFixture]
    public class TestCalculator
    {
        private readonly List<double> values = new List<double> { 10, 5, 7, 15, 13, 12, 8, 7, 4, 2, 9 };

        [Test]
        public void Test_AverageByMean()
        {
            double expected = 8.3636363;

            double actual = Calculator.CalculateAverange(d => d.Sum() / d.Length, values.ToArray());

            Assert.AreEqual(expected, actual, 0.000001);
        }

        [Test]
        public void Test_AverageByMedian()
        {
            IAvgMethod method = new MeanMeth();

            double expected = 8.0;

            double actual = Calculator2.CalculateAverange(method, values.ToArray());

            Assert.AreEqual(expected, actual, 0.000001);
        }
    }
}