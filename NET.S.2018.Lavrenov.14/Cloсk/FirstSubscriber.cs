namespace Cloсk
{
    using System;

    /// <summary>
    /// Subscriber class
    /// </summary>
    public class FirstSubscriber
    {
        #region Public API

        /// <summary>
        /// Unregister from event
        /// </summary>
        /// <param name="clockManager">Event manager</param>
        public void Unregister(ClockManager clockManager)
        {
            clockManager.NewTimeOut -= FirstSubscriberMsg;
        }

        /// <summary>
        /// Register for event
        /// </summary>
        /// <param name="clockManager">Event manager</param>
        public void Register(ClockManager clockManager)
        {
            clockManager.NewTimeOut += FirstSubscriberMsg;
        }
        #endregion

        #region Private method

        private void FirstSubscriberMsg(object sender, NewTimeOutEventArgs e)
        {
            Console.WriteLine("Time is out (message from first subscriber)");
            Console.WriteLine($"It took: {e.Seconds} second(s)");
        }

        #endregion
    }
}
