namespace Customer.Tests
{
    using System;
    using System.Globalization;
    using NUnit.Framework;

    [TestFixture]
    public class CustomerTests
    {
        private readonly Customer _customer1 = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);

        [TestCase("NRC", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        [TestCase("nrc", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        [TestCase("N", ExpectedResult = "Customer record: Jeffrey Richter")]
        [TestCase("n", ExpectedResult = "Customer record: Jeffrey Richter")]
        [TestCase("NR", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00")]
        [TestCase("Nr", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00")]
        [TestCase("nr", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00")]
        [TestCase("nR", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00")]
        [TestCase("NC", ExpectedResult = "Customer record: Jeffrey Richter, +1 (425) 555-0100")]
        [TestCase("nC", ExpectedResult = "Customer record: Jeffrey Richter, +1 (425) 555-0100")]
        [TestCase("nc", ExpectedResult = "Customer record: Jeffrey Richter, +1 (425) 555-0100")]
        [TestCase("r", ExpectedResult = "Customer record: 1,000,000.00")]
        [TestCase("R", ExpectedResult = "Customer record: 1,000,000.00")]
        [TestCase("c", ExpectedResult = "Customer record: +1 (425) 555-0100")]
        [TestCase("C", ExpectedResult = "Customer record: +1 (425) 555-0100")]
        [TestCase("CRN", ExpectedResult = "Customer record: +1 (425) 555-0100, 1,000,000.00, Jeffrey Richter")]
        [TestCase("CNR", ExpectedResult = "Customer record: +1 (425) 555-0100, Jeffrey Richter, 1,000,000.00")]
        public string CustomerDifferentFormatTests(string format)
        {
            return _customer1.ToString(format, CultureInfo.InvariantCulture);
        }

        [TestCase("Richard fray", "33333", 21321)]
        [TestCase("Richard Fray", "33333", 32432)]
        [TestCase("Richard Fray", "+1 (25) 555-0100", 43543)]
        [TestCase("Richard Fray", "+1 555-0100", 435435)]
        [TestCase("RICHARD FRAY", "+2 (125) 555-0100", 234345324)]
        public void CtorWithWrongParameters_ArgumentExeption(string name, string phone, decimal revenue)
        {
            Assert.Throws<ArgumentException>(() => new Customer(name, phone, revenue));
        }

        [TestCase("QQQ")]
        [TestCase("a")]
        [TestCase("A")]
        [TestCase("QE")]
        [TestCase("QQ")]
        [TestCase("Qqw")]
        [TestCase("rq")]
        public void WrongFormat_FormatExeption(string format)
        {
            Assert.Throws<FormatException>(() => _customer1.ToString(format, CultureInfo.InvariantCulture));
        }


    }
}
