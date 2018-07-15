namespace BankAccount
{
    /// <summary>
    /// Gold account class with
    /// BalanceCost = 100_000;
    /// ReplenishmentCost = 10_000;
    /// </summary>
    public class GoldAccount : PersonAccount
    {
        /// <summary>
        /// Constructor for creating gold account
        /// </summary>
        /// <param name="id">An identification number</param>
        /// <param name="client">Information about clients</param>
        public GoldAccount(int id, Person client) : base(id, client)
        {
            BalanceCost = 100_000;
            ReplenishmentCost = 10_000;
        }
    }
}
