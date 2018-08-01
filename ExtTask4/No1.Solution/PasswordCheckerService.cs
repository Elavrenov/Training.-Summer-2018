using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No1.Solution
{
    public class PasswordCheckerService : IService
    {
        private readonly IRepository _repository;

        public PasswordCheckerService(IRepository repository)
        {
            _repository = repository;
        }

        public Tuple<bool, string> VerifyPassword(string password, Func<string, string, bool> func = null
        , string veryfyingString = null)
        {
            if (func == null && veryfyingString == null)
            {
                return DefaultVerify(password);
            }

            if (veryfyingString == null)
            {
                throw new ArgumentNullException(nameof(veryfyingString));
            }

            if (func != null)
            {
                if (func(password,veryfyingString))
                {
                    _repository.Create(password);
                }

                return Tuple.Create(func(password, veryfyingString), password);
            }

            return DefaultVerify(password);
        }

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
    }
}
