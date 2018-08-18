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
            RndBytesFileGenerator fileFileGenerator = new RndBytesFileGenerator();
            RndCharsFileGenerator charsFileGenerator = new RndCharsFileGenerator();

            fileFileGenerator.GenerateFiles(1,2);
            charsFileGenerator.GenerateFiles(3,4);
        }
    }
}
