using System;
using RepositoryLogic;
using GeneratorLogic;

namespace BankSystem
{
    /// <summary>
    /// Service for managing accounts
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly IRepository _repository;

        public AccountService(IRepository repository)
        {
            _repository = repository;
        }

        #region Public API

        /// <summary>
        /// Method opening account
        /// </summary>
        /// <param name="person">person</param>
        /// <param name="accountType">person</param>
        /// <param name="generator">person</param>
        public void OpenAccount(Person person, AccountType accountType, AccountNumberGenerator generator)
        {
            string id;

            switch (accountType)
            {
                case AccountType.BaseAccount:
                    id = generator.GenerateAccountNumber(new BaseAccGenerator());
                    break;

                case AccountType.SilverAccount:
                    id = generator.GenerateAccountNumber(new SilverAccGenerator());
                    break;

                case AccountType.GoldAccount:
                    id = generator.GenerateAccountNumber(new GoldAccGenerator());
                    break;

                case AccountType.PlatinumAccount:
                    id = generator.GenerateAccountNumber(new PlatinumAccGenerator());
                    break;

                default:
                    id = generator.GenerateAccountNumber(new BaseAccGenerator());
                    break;
            }

            _repository.Save(id, person.ToString(), 0);
            _repository.Create();

        }

        /// <summary>
        /// Method add amout on account
        /// </summary>
        /// <param name="id">Account name</param>
        /// <param name="value">amout</param>
        public void Deposite(string id, decimal value)
        {
            Account account;

            switch (id[0])
            {
                case 'B':
                    account = new BaseAccount(id, _repository.GetPerson());
                    break;

                case 'S':
                    account = new SilverAccount(id, _repository.GetPerson());
                    break;

                case 'G':
                    account = new GoldAccount(id, _repository.GetPerson());
                    break;

                case 'P':
                    account = new PlatinumAccount(id, _repository.GetPerson());
                    break; ;
                default:
                    account = new BaseAccount(id, _repository.GetPerson());
                    break;
            }

            account.Deposite(value);
            _repository.Update(id, account.Balance);

        }

        /// <summary>
        /// Method remove amout from account
        /// </summary>
        /// <param name="id">Account name</param>
        /// <param name="value">amout</param>
        public void WithDraw(string id, decimal value)
        {
            Account account;

            switch (id[0])
            {
                case 'B':
                    account = new BaseAccount(id, _repository.GetPerson());
                    break;

                case 'S':
                    account = new SilverAccount(id, _repository.GetPerson());
                    break;

                case 'G':
                    account = new GoldAccount(id, _repository.GetPerson());
                    break;

                case 'P':
                    account = new PlatinumAccount(id, _repository.GetPerson());
                    break; ;
                default:
                    account = new BaseAccount(id, _repository.GetPerson());
                    break;
            }

            account.WithDraw(value);
            _repository.Update(id, account.Balance);
        }

        /// <summary>
        /// Metod returns account name
        /// </summary>
        /// <returns>Account name</returns>
        public string GetId()
        {
            return _repository.GetId();
        }

        #endregion


    }
}
