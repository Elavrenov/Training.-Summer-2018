namespace BankAccount
{
    using System;

    /// <summary>
    /// Base class for working with the account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Amount of money on the account
        /// </summary>
        private decimal _accountValue;

        /// <summary>
        /// Property for get amout of money 
        /// </summary>
        protected string GetAccountValue => $"{_accountValue}";

        /// <summary>
        /// Account replenishment operation
        /// </summary>
        /// <param name="value">Amout</param>
        /// <exception cref="ArgumentException"><paramref name="value"/> must be greater than zero</exception>
        protected void AddOperation(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Operation is not possible, value must be greater than zero");
            }

            _accountValue += value;
        }

        /// <summary>
        /// Debit transaction
        /// </summary>
        /// <param name="value">Amout</param>
        /// <exception cref="ArgumentException"><paramref name="value"/> must be greater than zero</exception>
        protected void MinusOperation(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Operation is not possible, value must be greater than zero");
            }

            if (value > _accountValue)
            {
                throw new ArgumentException($"Operation is not possible with insufficient funds on the account");
            }

            _accountValue -= value;
        }
    }
}
