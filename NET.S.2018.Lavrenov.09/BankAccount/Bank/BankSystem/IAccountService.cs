using GeneratorLogic;

namespace BankSystem
{
    interface IAccountService
    {
        void OpenAccount(Person person, AccountType accountType, AccountNumberGenerator generator);
        void Deposite(string id, decimal value);
        void WithDraw(string id, decimal value);
        string GetId();
    }
}
