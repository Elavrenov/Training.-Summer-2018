using System;
using System.Configuration;
using static StreamsDemo.StreamsExtension;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //var source = ConfigurationManager.AppSettings["sourceFilePath"];

            //var destination = ConfigurationManager.AppSettings["destinationFiePath"];

            string source = "SourceText.txt";
            string destination = "OutputText.txt";

            Console.WriteLine($"ByteCopy() done. Total bytes: {ByByteCopy(source, destination)}");

            //Console.WriteLine($"InMemoryByteCopy() done. Total bytes: {InMemoryByByteCopy(source, destination)}");

            Console.WriteLine($"ByBlockCopy() done. Total bytes: {ByBlockCopy(source, destination)}");

            Console.WriteLine(IsContentEquals(source, destination));

            Console.ReadKey();

            //etc
        }
    }
}
