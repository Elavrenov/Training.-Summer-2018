using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No1.Solution
{
    public interface IService
    {
        Tuple<bool, string> VerifyPassword(string password, Func<string,string, bool> func
        , string veryfingString);
    }
}
