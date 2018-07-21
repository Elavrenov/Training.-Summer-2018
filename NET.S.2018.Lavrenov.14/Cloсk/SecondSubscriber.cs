namespace Cloсk
{
    using System;

    /// <summary>
    /// Subscriber class
    /// </summary>
    public class SecondSubscriber
    {

        #region Public API

        /// <summary>
        /// Unregister from event
        /// </summary>
        /// <param name="clockManager">Event manager</param>
        public void Unregister(ClockManager clockManager)
        {
            clockManager.NewTimeOut -= SecondSubscriberMsg;
        }

        /// <summary>
        /// Register for event
        /// </summary>
        /// <param name="clockManager">Event manager</param>
        public void Register(ClockManager clockManager)
        {
            clockManager.NewTimeOut += SecondSubscriberMsg;
        }

        #endregion

        #region Private method

        private void SecondSubscriberMsg(object sender, NewTimeOutEventArgs e)
        {
            Console.WriteLine("Time is out (message from second subscriber)");
            Console.WriteLine($"It took: {e.Seconds} second(s)");
        }

        #endregion
    }
}
