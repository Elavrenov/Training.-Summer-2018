using System;
using System.Text;

namespace GeneratorLogic
{
    public class AccountNumberGenerator
    {
        public string GenerateAccountNumber(IAccountNumberGenerator account)
        {
            StringBuilder sb = new StringBuilder(10);
            sb.Append(account.GenerateNumber());
            Random rd =new Random();

            for (int i = 1; i < sb.Length; i++)
            {
                sb.Append(rd.Next(10));
            }

            return sb.ToString();
        }
    }

    public class BaseAccGenerator : IAccountNumberGenerator
    {
        public string GenerateNumber() => "B";
    }

    public class SilverAccGenerator : IAccountNumberGenerator
    {
        public string GenerateNumber() => "S";
    }

    public class GoldAccGenerator : IAccountNumberGenerator
    {
        public string GenerateNumber() => "G";
    }

    public class PlatinumAccGenerator : IAccountNumberGenerator
    {
        public string GenerateNumber() => "P";
    }
}
