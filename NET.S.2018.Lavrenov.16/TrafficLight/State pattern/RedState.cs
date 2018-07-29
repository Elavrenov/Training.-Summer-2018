namespace TrafficLight
{
    using System;

    /// <summary>
    /// Class for simulate red color
    /// </summary>
    public class RedState : IState
    {
        private TrafficLight _trafficLight;

        public RedState(TrafficLight traficLight)
        {
            _trafficLight = traficLight;
        }
        public void TimeisOut(int secs)
        {
            Console.WriteLine("RED");
            Countdown.Start(secs);
        }

    }
}
