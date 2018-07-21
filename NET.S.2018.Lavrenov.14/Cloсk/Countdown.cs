namespace Cloсk
{
    using System;
    using System.Threading;

    /// <summary>
    /// Countdown class
    /// </summary>
    public static class Countdown
    {
        /// <summary>
        /// Starting countdown
        /// </summary>
        /// <param name="seconds">Start parameter</param>
        public static void Start(int seconds)
        {
            var dateTime = DateTime.Now;
            DateTime dt = dateTime.AddSeconds(-seconds);

            while (dateTime > dt)
            {
                var ticks = (dateTime - dt).Ticks;
                Console.Clear();
                Console.WriteLine(new DateTime(ticks).ToString("mm:HH:ss"));
                Thread.Sleep(1000);
                dt = dt.AddSeconds(1);
            }

            Console.Clear();
        }
    }
}
