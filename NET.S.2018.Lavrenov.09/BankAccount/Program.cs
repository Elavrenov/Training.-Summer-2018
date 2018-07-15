namespace BankAccount
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Person client1 = new Person("Jeff","Razz","st.1,h.1");
            Person client2 = new Person("Jack","Wolf","st.2,h.2");
            Person client3 = new Person("Garold","Vich","st.3,h.3");
            Person client4 = new Person("Vitaliy","Kravcenko","st.4,h.4");

            BaseAccount baseAcc = new BaseAccount(1,client1);
            SilverAccount silverAcc = new SilverAccount(2,client2);
            GoldAccount goldAcc = new GoldAccount(3,client3);
            PlatinumAccount platinumAcc = new PlatinumAccount(4,client4);

            #region Base account tests

            //baseAcc.ReplenishmentOperation(100,1);//Exception: You don't have any account, please create new account
            baseAcc.CreateNewAccount();
            //baseAcc.DeleteAccount(1);//Exception: Wrong account number
            baseAcc.ReplenishmentOperation(100000,0);
            baseAcc.ReplenishmentOperation(10,0);
            baseAcc.ReplenishmentOperation(1000000,0);
            baseAcc.WriteOffOperation(1000000,0);
            //baseAcc.ReplenishmentOperation(-100,0);// Exception: Operation is not possible, value must be greater than zero
            //baseAcc.WriteOffOperation(1000000,0);//Exception: Operation is not possible with insufficient funds on the account
            //baseAcc.WriteOffOperation(-100000,0);Exception: Operation is not possible, value must be greater than zero
            baseAcc.WriteOffOperation(100000,0);
            baseAcc.GetPersonAccountInfo();//Remained only bonus money
            baseAcc.CreateNewAccount();
            baseAcc.ReplenishmentOperation(100,1);
            baseAcc.ReplenishmentOperation(1000000,1);
            baseAcc.GetPersonAccountInfo();
            baseAcc.DeleteAccount(1);
            baseAcc.DeleteAccount(0);
            baseAcc.GetPersonAccountInfo();

            #endregion

            Console.WriteLine();

            #region Silver account tests

            //silverAcc.ReplenishmentOperation(100,1);//Exception: You don't have any account, please create new account
            silverAcc.CreateNewAccount();
            //silverAcc.DeleteAccount(1);//Exception: Wrong account number
            silverAcc.ReplenishmentOperation(100000,0);
            silverAcc.ReplenishmentOperation(10,0);
            silverAcc.ReplenishmentOperation(1000000,0);
            silverAcc.WriteOffOperation(1000000,0);
            //silverAcc.ReplenishmentOperation(-100,0);// Exception: Operation is not possible, value  must be greater than zero
            //silverAcc.WriteOffOperation(1000000,0);//Exception: Operation is not possible with insufficient funds on the account
            //silverAcc.WriteOffOperation(-100000,0);Exception: Operation is not possible, value must be greater than zero
            silverAcc.WriteOffOperation(100000,0);
            silverAcc.GetPersonAccountInfo();//Remained only bonus money
            silverAcc.CreateNewAccount();
            silverAcc.ReplenishmentOperation(100,1);
            silverAcc.ReplenishmentOperation(1000000,1);
            silverAcc.GetPersonAccountInfo();
            silverAcc.DeleteAccount(1);
            silverAcc.DeleteAccount(0);
            silverAcc.GetPersonAccountInfo();

            #endregion

            Console.WriteLine();

            #region Gold account tests

            //goldAcc.ReplenishmentOperation(100,1);//Exception: You don't have any account, please create new account
            goldAcc.CreateNewAccount();
            //goldAcc.DeleteAccount(1);//Exception: Wrong account number
            goldAcc.ReplenishmentOperation(100000, 0);
            goldAcc.ReplenishmentOperation(10, 0);
            goldAcc.ReplenishmentOperation(1000000, 0);
            goldAcc.WriteOffOperation(1000000, 0);
            //goldAcc.ReplenishmentOperation(-100,0);// Exception: Operation is not possible, value must be greater than zero
            //goldAcc.WriteOffOperation(1000000,0);//Exception: Operation is not possible with insufficient funds on the account
            //goldAcc.WriteOffOperation(-100000,0);Exception: Operation is not possible, value must be greater than zero
            goldAcc.WriteOffOperation(100000, 0);
            goldAcc.GetPersonAccountInfo();//Remained only bonus money
            goldAcc.CreateNewAccount();
            goldAcc.ReplenishmentOperation(100, 1);
            goldAcc.ReplenishmentOperation(1000000, 1);
            goldAcc.GetPersonAccountInfo();
            goldAcc.DeleteAccount(1);
            goldAcc.DeleteAccount(0);
            goldAcc.GetPersonAccountInfo();

            #endregion

            Console.WriteLine();

            #region Platinum account tests

            //platinumAcc.ReplenishmentOperation(100,1);//Exception: You don't have any account, please create new account
            platinumAcc.CreateNewAccount();
            //platinumAcc.DeleteAccount(1);//Exception: Wrong account number
            platinumAcc.ReplenishmentOperation(100000, 0);
            platinumAcc.ReplenishmentOperation(10, 0);
            platinumAcc.ReplenishmentOperation(1000000, 0);
            platinumAcc.WriteOffOperation(1000000, 0);
            //platinumAcc.ReplenishmentOperation(-100,0);// Exception: Operation is not possible, value must be greater than zero
            //platinumAcc.WriteOffOperation(1000000,0);//Exception: Operation is not possible with insufficient funds on the account
            //platinumAcc.WriteOffOperation(-100000,0);Exception: Operation is not possible, value must be greater than zero
            platinumAcc.WriteOffOperation(100000, 0);
            platinumAcc.GetPersonAccountInfo();//Remained only bonus money
            platinumAcc.CreateNewAccount();
            platinumAcc.ReplenishmentOperation(100, 1);
            platinumAcc.ReplenishmentOperation(1000000, 1);
            platinumAcc.GetPersonAccountInfo();
            platinumAcc.DeleteAccount(1);
            platinumAcc.DeleteAccount(0);
            platinumAcc.GetPersonAccountInfo();

            #endregion

            Console.ReadKey();
        }
    }
}
