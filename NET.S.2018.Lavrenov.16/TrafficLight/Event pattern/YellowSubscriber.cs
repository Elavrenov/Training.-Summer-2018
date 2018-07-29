namespace TrafficLight.Event_pattern
{
    using System;

    public class YellowSubscriber
    {
        #region Public API

        /// <summary>
        /// Unregister from event
        /// </summary>
        /// <param name="trafficLightManager">Event manager</param>
        public void Unregister(TrafficLightManager trafficLightManager)
        {
            trafficLightManager.NewTimeOut -= FirstSubscriberMsg;
        }

        /// <summary>
        /// Register for event
        /// </summary>
        /// <param name="trafficLightManager">Event manager</param>
        public void Register(TrafficLightManager trafficLightManager)
        {
            trafficLightManager.NewTimeOut += FirstSubscriberMsg;
        }
        #endregion

        #region Private method

        private void FirstSubscriberMsg(object sender, NewTimeOutEventArgs e)
        {
            Console.WriteLine("YELLOW");
        }

        #endregion
    }
}
