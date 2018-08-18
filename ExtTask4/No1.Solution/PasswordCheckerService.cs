using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No1.Solution
{
    public class PasswordCheckerService
    {
        private readonly IRepository _repository;

        public PasswordCheckerService(IRepository repository)
        {
            _repository = repository;
        }

        public bool VerifyPassword(string password, IEnumerable<Tuple<bool, string>> tuples = null)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException($"wrong password");
            }

            if (tuples != null)
            {
                foreach (var tuple in tuples)
                {
                    if (!tuple.Item1)
                    {
                        return false;
                    }

                }
            }

            return true;
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
