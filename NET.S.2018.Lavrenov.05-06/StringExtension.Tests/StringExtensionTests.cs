using System;
using NUnit.Framework;

namespace StringExtension.Tests
{
    [TestFixture]
    public class StringExtensionTests
    {
        [TestCase("0110111101100001100001010111111", 2, ExpectedResult = 934331071)]
        [TestCase("01101111011001100001010111111", 2, ExpectedResult = 233620159)]
        [TestCase("11101101111011001100001010", 2, ExpectedResult = 62370570)]
        [TestCase("1AeF101", 16, ExpectedResult = 28242177)]
        [TestCase("1ACB67", 16, ExpectedResult = 1756007)]
        [TestCase("764241", 8, ExpectedResult = 256161)]
        [TestCase("10", 5, ExpectedResult = 5)]
        [TestCase("1243311", 8, ExpectedResult = 345801)]
        [TestCase("01221112", 3, ExpectedResult = 1418)]
        public int StringExtension_Tests(string actual, int notation)
        {
            return actual.ConvertToInt32(notation);
        }

        [TestCase("1AeF101", 2)]
        [TestCase("-1AeF101", 2)]
        [TestCase("SA123", 2)]
        [TestCase("FFAA2",3)]
        [TestCase("764241", 20)]
        [TestCase("-10", 5)]
        public void StringExtension_Tests_ArgumentExteptions(string actual, int notation)
        {
            Assert.Throws<ArgumentException>(() => actual.ConvertToInt32(notation));
        }

        [TestCase("FFFFFFFFFFFFFFFFFFFFF4444444444422", 16)]
        [TestCase("11111111111111111111111111111111", 2)]
        [TestCase("111111111111111111111111111111110001", 2)]
        public void StringExtension_Tests_OverflowExteptions(string actual, int notation)
        {
            Assert.Throws<OverflowException>(() => actual.ConvertToInt32(notation));
        }
    }
}
