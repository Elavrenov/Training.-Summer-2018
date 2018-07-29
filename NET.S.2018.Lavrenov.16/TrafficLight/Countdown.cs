namespace TrafficLight
{
    using System;
    using System.Threading;

    /// <summary>
    /// Class for simulate timer
    /// </summary>
    public static class Countdown
    {
        public static void Start(int seconds)
        {
            var dateTime = DateTime.Now;
            DateTime dt = dateTime.AddSeconds(-seconds);

            while (dateTime > dt)
            {
                var ticks = (dateTime - dt).Ticks;
                Console.WriteLine(new DateTime(ticks).ToString("ss"));
                Thread.Sleep(1000);
                dt = dt.AddSeconds(1);
            }

            Console.Clear();
        }
    }
}
