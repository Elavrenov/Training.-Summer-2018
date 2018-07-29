namespace TrafficLight
{
    using System;

    /// <summary>
    /// Class for simulate yellow color
    /// </summary>
    public class YellowState : IState
    {
        private TrafficLight _trafficLight;

        public YellowState(TrafficLight traficLight)
        {
            _trafficLight = traficLight;
        }
        public void TimeisOut(int secs)
        {
            Console.WriteLine("YELLOW");
            Countdown.Start(secs / 5);
        }

    }
}
