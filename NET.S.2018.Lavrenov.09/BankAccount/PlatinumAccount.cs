namespace BankAccount
{
    /// <summary>
    /// Platunim account class with
    /// BalanceCost = 100_000;
    /// ReplenishmentCost = 100_000;
    /// </summary>
    public class PlatinumAccount:PersonAccount
    {
        /// <summary>
        /// Constructor for creating platinum account
        /// </summary>
        /// <param name="id">An identification number</param>
        /// <param name="client">Information about clients</param>
        public PlatinumAccount(int id, Person client) : base(id, client)
        {
            BalanceCost = 100_000;
            ReplenishmentCost = 100_000;
        }
    }
}
