﻿using System.Linq;
using NUnit.Framework;

namespace No6.Solution.Tests
{
    [TestFixture]
    public class CustomEnumerableTests
    {
        [Test]
        public void Generator_ForSequence1()
        {
            int[] expected = { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 };

            int[] actual = Generator<int>.GetSequence(1, 1, (x, y) => x + y, 10).ToArray();

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Generator_ForSequence2()
        {
            int[] expected = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 };

            int[] actual = Generator<int>.GetSequence(1, 2, (x, y) => 6 * x - 8 * y, 10).ToArray();

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Generator_ForSequence3()
        {
            double[] expected = { 1, 2, 2.5, 3.3, 4.05757575757576, 4.87086926018965, 5.70389834408211, 6.55785277425587, 7.42763417076325, 8.31053343902137 };

            double[] actual = Generator<double>.GetSequence(1, 2, (x, y) => x + y / x, 10).ToArray();

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(expected[i], actual[i], 0.00001);
            }

        }
    }
}
