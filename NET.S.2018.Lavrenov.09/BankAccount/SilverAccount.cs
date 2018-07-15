namespace BankAccount
{
    /// <summary>
    /// Silver account class with
    /// BalanceCost = 10_000;
    /// ReplenishmentCost = 1_000;
    /// </summary>
    public class SilverAccount:PersonAccount
    {
        /// <summary>
        /// Constructor for creating silver account
        /// </summary>
        /// <param name="id">An identification number</param>
        /// <param name="client">Information about clients</param>
        public SilverAccount(int id, Person client) : base(id, client)
        {
            BalanceCost = 10_000;
            ReplenishmentCost = 1_000;
        }
    }
}
