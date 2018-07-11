using System;
using System.Globalization;
using NUnit.Framework;

namespace CustomerProvider.Tests
{
    using Customer;

    [TestFixture]
    public class CustomerProviderTests
    {
        private readonly Customer _customer1 = new Customer("Jeff Ric", "+1 (425) 555-0100", 100);

        [TestCase("QWERTY", ExpectedResult = "Customer record: Jeff Ric, 100.00, +1 (425) 555-0100 QWERTY")]
        [TestCase("NRC", ExpectedResult = "Customer record: Jeff Ric, 100.00, +1 (425) 555-0100")]
        [TestCase("NC", ExpectedResult = "Customer record: Jeff Ric, +1 (425) 555-0100")]
        [TestCase("NR", ExpectedResult = "Customer record: Jeff Ric, 100,00")]
        [TestCase("N", ExpectedResult = "Customer record: Jeff Ric")]
        public string CustomerProviderDifferentFormatTests(string format)
        {
            return new CustomerProvider().Format(format, _customer1, CultureInfo.InvariantCulture);
        }

        [Test]
        public void CustomerProvderWithWrongType()
        {
            Assert.Throws<ArgumentException>(() => new CustomerProvider()
                .Format("QWERTY", int.MaxValue, CultureInfo.InvariantCulture));
        }
    }
}
