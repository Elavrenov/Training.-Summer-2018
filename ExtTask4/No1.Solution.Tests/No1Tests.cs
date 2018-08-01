using System;
using NUnit.Framework;

namespace No1.Solution.Tests
{
    [TestFixture]
    public class No1Tests
    {
        private IRepository _repository = new SqlRepository();

        [Test]
        public void Test1()
        {
            PasswordCheckerService pcService = new PasswordCheckerService(_repository);

            Tuple<bool, string> expTuple = Tuple.Create(true, "Password is Ok. User was created");

            var tuple = pcService.VerifyPassword("Hello777r");

            Assert.AreEqual(expTuple, tuple);
        }

        [Test]
        public void Test2()
        {
            PasswordCheckerService pcService = new PasswordCheckerService(_repository);

            Tuple<bool, string> expTuple = Tuple.Create(true, "Monster");

            var tuple = pcService.VerifyPassword("Monster", (a, b) => a == b, "Monster");

            Assert.AreEqual(expTuple, tuple);
        }
    }

}
