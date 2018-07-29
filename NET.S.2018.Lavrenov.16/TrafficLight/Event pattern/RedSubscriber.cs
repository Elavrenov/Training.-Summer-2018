using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight.Event_pattern
{
    public class RedSubscriber
    {
        #region Public API

        /// <summary>
        /// Unregister from event
        /// </summary>
        /// <param name="traficLightManager">Event manager</param>
        public void Unregister(TrafficLightManager traficLightManager)
        {
            traficLightManager.NewTimeOut -= FirstSubscriberMsg;
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
            Console.WriteLine("RED");
        }

        #endregion
    }
}
