using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace No1.Solution.Tests
{
    [TestFixture]
    public class No1Tests
    {
        private IRepository _repository = new SqlRepository();
        private Tuple<bool, string> DefaultVerify(string password)
        {
            if (password == null)
                throw new ArgumentException($"{password} is null arg");

            if (password == string.Empty)
                return Tuple.Create(false, $"{password} is empty ");

            // check if length more than 7 chars 
            if (password.Length <= 7)
                return Tuple.Create(false, $"{password} length too short");

            // check if length more than 10 chars for admins
            if (password.Length >= 15)
                return Tuple.Create(false, $"{password} length too long");

            // check if password conatins at least one alphabetical character 
            if (!password.Any(char.IsLetter))
                return Tuple.Create(false, $"{password} hasn't alphanumerical chars");

            // check if password conatins at least one digit character 
            if (!password.Any(char.IsNumber))
                return Tuple.Create(false, $"{password} hasn't digits");

            _repository.Create(password);

            return Tuple.Create(true, "Password is Ok. User was created");
        }

        [Test]
        public void Test1()
        {
            PasswordCheckerService pcService = new PasswordCheckerService(_repository);

            Tuple<bool, string> expTuple = Tuple.Create(true, "Password is Ok. User was created");

            var tuple = pcService.VerifyPassword("Hello777r");

            Assert.AreEqual(expTuple.Item1, tuple);
        }

        [Test]
        public void Test2()
        {
            PasswordCheckerService pcService = new PasswordCheckerService(_repository);

            Tuple<bool, string> expTuple = DefaultVerify("Hello777r");

            List<Tuple<bool,string>> list = new List<Tuple<bool, string>>();
            list.Add(expTuple);

            var tuple = pcService.VerifyPassword("Hello777r", list);

            Assert.IsTrue(tuple);
        }
    }

}
