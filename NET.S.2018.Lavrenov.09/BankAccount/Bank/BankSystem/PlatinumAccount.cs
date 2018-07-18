namespace BankSystem
{
    /// <summary>
    /// Platinum account
    /// </summary>
    public class PlatinumAccount : Account
    {
        #region Ctors

        public PlatinumAccount(string id, string person) : base(id, person)
        {
        }

        public PlatinumAccount(string id, string person, decimal balance) : base(id, person, balance)
        {
        }

        public PlatinumAccount(string id, string person, decimal balance, AccountType accType) : base(id, person, balance, accType)
        {
        }

        #endregion

        #region Overrided Account methods

        protected override bool IsValidBalance(decimal value)
        {
            return value > -1_000_000;
        }

        protected override int CalculateBonusPoints(decimal value)
        {
            return (int)(value * 0.50M + Balance / 1000);
        }

        #endregion

        
    }
}
