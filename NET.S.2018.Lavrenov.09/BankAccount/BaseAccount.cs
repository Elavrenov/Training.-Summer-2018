namespace BankAccount
{
    /// <summary>
    /// Base account class with
    /// BalanceCost = 1_000;
    /// ReplenishmentCost = 100;
    /// </summary>
    public class BaseAccount : PersonAccount
    {
        /// <summary>
        /// Constructor for creating base account
        /// </summary>
        /// <param name="id">An identification number</param>
        /// <param name="client">Information about clients</param>
        public BaseAccount(int id, Person client) : base(id, client)
        {
            BalanceCost = 1_000;
            ReplenishmentCost = 100;
        }
    }
}
