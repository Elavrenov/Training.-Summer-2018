﻿namespace BankSystem
{
    /// <summary>
    /// Gold account
    /// </summary>
    public class GoldAccount : Account
    {
        #region Ctors

        public GoldAccount(string id, string person) : base(id, person)
        {
        }

        public GoldAccount(string id, string person, decimal balance) : base(id, person, balance)
        {
        }

        public GoldAccount(string id, string person, decimal balance, AccountType accType) : base(id, person, balance, accType)
        {
        }

        #endregion
        
        #region Overrided Account methods

        protected override bool IsValidBalance(decimal value)
        {
            return value > -1000;
        }

        protected override int CalculateBonusPoints(decimal value)
        {
            return (int)(value * 0.10M + Balance / 1000);
        }

        #endregion
    }
}
