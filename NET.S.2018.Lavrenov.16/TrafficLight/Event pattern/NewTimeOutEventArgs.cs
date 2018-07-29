namespace TrafficLight.Event_pattern
{
    using System;
    public class NewTimeOutEventArgs : EventArgs
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="seconds">Number of seconds</param>
        public NewTimeOutEventArgs(int seconds)
        {
            Seconds = seconds;
        }

        public int Seconds { get; }
    }
}
