namespace BankAccount
{
    using System;
    using System.Collections.Generic;

    public class PersonAccount : Account
    {
        #region Fields

        /// <summary>
        /// An identification number
        /// </summary>
        private readonly int _id;

        /// <summary>
        /// Client
        /// </summary>
        private readonly Person _client;

        /// <summary>
        /// Bonus points
        /// </summary>
        private int _bonusPoints;

        /// <summary>
        /// Client accounts
        /// </summary>
        private readonly List<PersonAccount> _accounts;


        /// <summary>
        /// Balance cost
        /// </summary>
        protected int BalanceCost;

        /// <summary>
        /// Replenishment cost
        /// </summary>
        protected int ReplenishmentCost;

        #endregion

        #region Constuctor

        /// <summary>
        /// Constructor for creating bank account
        /// </summary>
        /// <param name="id">An identification number</param>
        /// <param name="client">Client</param>
        public PersonAccount(int id, Person client)
        {
            _id = id;
            _client = client;
            _accounts = new List<PersonAccount>();
        }

        #endregion

        #region Public API

        /// <summary>
        /// The operation of replenishing the account with the accrual of bonus points
        /// proceeding from the logic ReplenishmentCost and BalanceCost
        /// </summary>
        /// <param name="value">Amonut</param>
        /// <param name="accountNumber">Account number for which you need to transfer money</param>
        /// <exception cref="ArgumentException">if client has not accounts or account number is wrong</exception>
        public void ReplenishmentOperation(decimal value, int accountNumber)
        {
            if (_accounts.Count == 0)
            {
                throw new ArgumentException("You don't have any account or wrong account number, please create new account");
            }

            if (accountNumber < 0 || accountNumber >= _accounts.Count)
            {
                throw new ArgumentException("Wrong account number");
            }

            if (accountNumber < _accounts.Count)
            {
                if (value >= ReplenishmentCost && value >= BalanceCost)
                {
                    _bonusPoints = _bonusPoints + (ReplenishmentCost + BalanceCost) / 1000;
                }

                _accounts[accountNumber].AddOperation(value + _bonusPoints);
            }

        }

        /// <summary>
        /// The operation of write-off the account with the write-off of bonus points
        /// proceeding from the logic ReplenishmentCost and BalanceCost
        /// </summary>
        /// <param name="value">Amonut</param>
        /// <param name="accountNumber">Account number for which you need write-off money</param>
        /// <exception cref="ArgumentException">if client has not accounts or account number is wrong</exception>
        public void WriteOffOperation(decimal value, int accountNumber)
        {
            if (_accounts.Count == 0)
            {
                throw new ArgumentException("You don't have any account or wrong account number, please create new account");
            }

            if (accountNumber < 0 || accountNumber >= _accounts.Count)
            {
                throw new ArgumentException("Wrong account number");
            }

            if (accountNumber < _accounts.Count)
            {
                if (value >= ReplenishmentCost && value <= BalanceCost)
                {
                    _bonusPoints = _bonusPoints - (ReplenishmentCost + BalanceCost) / 1000;
                }

                _accounts[accountNumber].MinusOperation(value + _bonusPoints);
            }
        }

        /// <summary>
        /// Method for creating new account
        /// </summary>
        public void CreateNewAccount()
        {
            _accounts.Add(new PersonAccount(_id, _client));
        }

        /// <summary>
        /// Method for remove account
        /// </summary>
        /// <param name="accountNumber">Account number for which you need to remove</param>
        /// <exception cref="ArgumentException">if client has not accounts or account number is wrong</exception>
        public void DeleteAccount(int accountNumber)
        {
            if (_accounts.Count == 0)
            {
                throw new ArgumentException("You don't have any account or wrong account number, please create new account");
            }

            if (accountNumber < 0 || accountNumber >= _accounts.Count)
            {
                throw new ArgumentException("Wrong account number");
            }

            if (accountNumber < _accounts.Capacity)
            {
                _accounts.RemoveAt(accountNumber);
            }
        }

        /// <summary>
        /// Method for giving account information
        /// </summary>
        public void GetPersonAccountInfo()
        {
            _client.GetPersonInfo();

            if (_accounts.Count == 0)
            {
                Console.WriteLine("There are no open accounts");
                return;
            }

            int i = 0;

            Console.WriteLine("Accounts:");
            foreach (var item in _accounts)
            {
                Console.WriteLine($"{++i}: ${item.GetAccountValue}");
            }
        }

        #endregion        
    }
}
