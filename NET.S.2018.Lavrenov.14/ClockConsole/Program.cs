namespace ClockConsole
{
    using System;
    using System.Threading;
    using Cloсk;
    class Program
    {
        static void Main(string[] args)
        {
            ClockManager clockManager = new ClockManager();

            FirstSubscriber sub1 = new FirstSubscriber();
            SecondSubscriber sub2 = new SecondSubscriber();

            sub1.Register(clockManager);
            sub2.Register(clockManager);

            clockManager.SimulateTimeOut(5);
            Thread.Sleep(5000);
            clockManager.SimulateTimeOut(3);
            Thread.Sleep(5000);
            sub1.Unregister(clockManager);
            clockManager.SimulateTimeOut(4);
           

            Console.ReadKey();

        }
    }
}
