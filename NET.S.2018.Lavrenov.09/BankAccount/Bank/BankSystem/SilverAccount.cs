namespace BankSystem
{
    /// <summary>
    /// silver account
    /// </summary>
    public class SilverAccount : Account
    {
        #region Ctros
        public SilverAccount(string id, string person) : base(id, person)
        {
        }

        public SilverAccount(string id, string person, decimal balance) : base(id, person, balance)
        {
        }

        public SilverAccount(string id, string person, decimal balance, AccountType accType) : base(id, person, balance, accType)
        {
        }

        #endregion

        #region Overrided Account methods

         protected override bool IsValidBalance(decimal value)
         {
             return value >= 0;
         }

        protected override int CalculateBonusPoints(decimal value)
        {
            return (int)(value * 0.05M + Balance / 1000);
        }

        #endregion
       
    }
}
