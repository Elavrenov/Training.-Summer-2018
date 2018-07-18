using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem;
using GeneratorLogic;
using RepositoryLogic;

namespace BankConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Garold","Cash","cash@gmai.com");
            Person person2 = new Person("Vitya","Bove","bove@gmail.com");

            AccountNumberGenerator generator = new AccountNumberGenerator();
            Repository repository = new Repository();
            AccountService accountService = new AccountService(repository);

            accountService.OpenAccount(person1,AccountType.PlatinumAccount,generator);
            accountService.Deposite(accountService.GetId(),10000);
            accountService.Deposite(accountService.GetId(), 10000);
            accountService.Deposite(accountService.GetId(), 10000);
            accountService.WithDraw(accountService.GetId(), 10000);
            accountService.WithDraw(accountService.GetId(), 10000);
            accountService.Deposite(accountService.GetId(), 10000);
            accountService.OpenAccount(person1,AccountType.GoldAccount,generator);


            accountService.OpenAccount(person2, AccountType.PlatinumAccount, generator);
            accountService.Deposite(accountService.GetId(), 10000);
            accountService.Deposite(accountService.GetId(), 10000);
           // accountService.Deposite(accountService.GetId(), 10000);
            accountService.WithDraw(accountService.GetId(), 10000);
            accountService.WithDraw(accountService.GetId(), 10000);
            accountService.Deposite(accountService.GetId(), 10000);
            accountService.OpenAccount(person2, AccountType.GoldAccount, generator);

        }
    }
}
