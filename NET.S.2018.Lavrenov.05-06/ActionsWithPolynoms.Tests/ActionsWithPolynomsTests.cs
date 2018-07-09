using NUnit.Framework;


namespace ActionsWithPolynoms.Tests
{
    [TestFixture()]
    public class ActionsWithPolynomsTests
    {
        private static readonly double[] FirstInitArray = { 4.12, -23.5, 0, -43 };
        private static readonly double[] SecondInitArray = { -0.2, 5.6, 11.888 };

        private static readonly Polynomial FirstPolynomial = new Polynomial(FirstInitArray);
        private static readonly Polynomial SecondPolynomial = new Polynomial(SecondInitArray);

        [Test]
        public void Polynomial_ToStringTest()
        {
            double[] array = { -4.43, -4.5, 234, 0 };
            Polynomial polynomial = new Polynomial(array);
            string result = "(-4,43)x^3 + (-4,5)x^2 + (234)x^1 + (0)";

            Assert.AreEqual(polynomial.ToString(), result);
        }

        [Test]
        public void Polynomial_AddTest()
        {
            double[] expectedArray = { 3.92, -17.9, 11.888, -43 };

            Polynomial actual = FirstPolynomial + SecondPolynomial;
            Polynomial expected = new Polynomial(expectedArray);

            Assert.AreEqual(actual.ToString(), expected.ToString());
        }

        [Test]
        public void Polynomial_SubstructTest()
        {
            double[] expectedArray = { 4.32, -29.1, -11.888, -43 };

            Polynomial actual = FirstPolynomial - SecondPolynomial;
            Polynomial expected = new Polynomial(expectedArray);

            Assert.AreEqual(actual.ToString(), expected.ToString());
        }

        [Test]
        public void Polynomial_MultyplyTest()
        {
            double[] expectedArray = { 8.24, -47, 0, -86 };

            Polynomial actual = FirstPolynomial * 2;
            Polynomial expected = new Polynomial(expectedArray);

            Assert.AreEqual(actual.ToString(), expected.ToString());
        }

        [Test]
        public void Polynomial_MultyplyTest1()
        {
            double[] expectedArray = { -0.824, 27.772, -82.62144, -270.768, -240.8, -511.184 };

            Polynomial actual = FirstPolynomial * SecondPolynomial;
            Polynomial expected = new Polynomial(expectedArray);

            Assert.AreEqual(actual.ToString(), expected.ToString());
        }

        [Test]
        public void Polynomial_MultyplyTest2()
        {
            double[] expectedArray = { 8.24, -47, 0, -86 };

            Polynomial actual = 2 * FirstPolynomial;
            Polynomial expected = new Polynomial(expectedArray);

            Assert.AreEqual(actual.ToString(), expected.ToString());
        }

        [Test]
        public void Polynomial_DivisionTest()
        {
            double[] expectedArray = { 2.06, -11.75, 0, -21.5 };

            Polynomial actual = FirstPolynomial / 2;
            Polynomial expected = new Polynomial(expectedArray);

            Assert.AreEqual(actual.ToString(), expected.ToString());
        }


        [TestCase(new[] { 1, 1.54, 2, -5, 4, 42.11 }, new[] { 1, 1.54, 2, -5, 4, 42.11 }, ExpectedResult = true)]
        public bool Polynom_EqualsTest1(double[] firstArray, double[] secondArray)
        {
            Polynomial left = new Polynomial(firstArray);
            Polynomial right = new Polynomial(secondArray);

            return left == right;
        }

        [TestCase(new[] { 1, 1.54, 2, -5, 4, 42.11 }, new[] { 1, 1.54, 2, -5, 4, 42.11 }, ExpectedResult = true)]
        public bool Polynom_EqualsTest2(double[] firstArray, double[] secondArray)
        {
            Polynomial left = new Polynomial(firstArray);
            Polynomial right = new Polynomial(secondArray);

            return left.Equals(right);
        }

        [TestCase(new[] { 1, 1.54, 2, -5, 4, 42.11 }, ExpectedResult = true)]
        public bool Polynom_EqualsTest3(double[] firstArray)
        {
            Polynomial left = new Polynomial(firstArray);

            return left.Equals(left);
        }

        [TestCase(new[] { 1, 1.54, 2, -5, 4, 42.11 }, new[] { 1, 1.54, 2, -5, 4, 42.11 }, ExpectedResult = false)]
        public bool Polynom_NonEqualsTest(double[] firstArray, double[] secondArray)
        {
            Polynomial left = new Polynomial(firstArray);
            Polynomial right = new Polynomial(secondArray);

            return left != right;
        }

    }
}
