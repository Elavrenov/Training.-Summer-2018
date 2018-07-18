namespace BankSystem
{
    /// <summary>
    /// BAse account
    /// </summary>
    public class BaseAccount : Account
    {
        #region Ctors
        public BaseAccount(string id, string person) : base(id, person)
        {
        }

        public BaseAccount(string id, string person, decimal balance) : base(id, person, balance)
        {
        }

        public BaseAccount(string id, string person, decimal balance, AccountType accType) : base(id, person, balance, accType)
        {
        }

        #endregion

        #region Ovverrided Account methods

        protected override bool IsValidBalance(decimal value)
        {
            return value >= 0;
        }

        protected override int CalculateBonusPoints(decimal value)
        {
            return (int) (value*0.01M + Balance/1000);
        }

        #endregion
        
    }
}
