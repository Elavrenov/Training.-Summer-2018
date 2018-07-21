namespace Cloсk
{
    using System;

    /// <summary>
    /// class for determining the type for storing all additional information 
    /// transmitted to the recipients of the event notification
    /// </summary>
    public class NewTimeOutEventArgs:EventArgs
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
