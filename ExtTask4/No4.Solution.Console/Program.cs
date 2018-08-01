using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No4.Solution.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IGenerator byteGenerator = new RndBytesFileGen();
            IGenerator charGenerator = new RndCharsFileGen();

            Service serv1 = new Service(byteGenerator);
            Service serv2 = new Service(charGenerator);

            serv1.GenerateFiles(1,3);
            serv2.GenerateFiles(2,4);
        }
    }
}
