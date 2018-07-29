namespace TrafficLight
{
    using System;

    /// <summary>
    /// Class for simulate green color
    /// </summary>
    public class GreenState : IState
    {
        private TrafficLight _trafficLight;

        public GreenState(TrafficLight traficLight)
        {
            _trafficLight = traficLight;
        }
        public void TimeisOut(int secs)
        {
            Console.WriteLine("GREEN");
            Countdown.Start(secs / 2);
        }
    }
}
