namespace Cloсk
{
    using System;

    /// <summary>
    /// Class for initializing an event
    /// </summary>
    public class ClockManager
    {
        /// <summary>
        /// Event
        /// </summary>
        public event EventHandler<NewTimeOutEventArgs> NewTimeOut;

        /// <summary>
        /// Event start
        /// </summary>
        /// <param name="seconds">Start parameter</param>
        public void SimulateTimeOut(int seconds)
        {
            Countdown.Start(seconds);
            var e = new NewTimeOutEventArgs(seconds);
            OnNewTimeOut(e);
        }

        #region Protected virtual

        /// <summary>
        /// Method for event execution
        /// </summary>
        /// <param name="e">Exemplar of class wiht additional ingo</param>
        protected virtual void OnNewTimeOut(NewTimeOutEventArgs e)
        {
            var temp = NewTimeOut;
            temp?.Invoke(this, e);
        }

        #endregion
        
    }
}
