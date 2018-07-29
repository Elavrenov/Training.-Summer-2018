using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrafficLight;
using TrafficLight.Event_pattern;

namespace TrafficLightPL
{
    using TrafficLight;

    class Program
    {
        static void Main(string[] args)
        {
            // 1 variant //////////////////

            //TrafficLight tr = new TrafficLight();

            //while (true)
            //{
            //    tr.TimeOut();
            //    tr.SetState(new YellowState(tr));
            //    tr.TimeOut();
            //    tr.SetState(new GreenState(tr));
            //    tr.TimeOut();
            //    tr.SetState(new RedState(tr));
            //}

            // 2 variant /////////////////

            //TrafficLightManager manager = new TrafficLightManager();

            //RedSubscriber red = new RedSubscriber();
            //YellowSubscriber yellow = new YellowSubscriber();
            //GreenSubscriber green = new GreenSubscriber();

            //red.Register(manager);
            //manager.SimulateTimeOut(5);
            //Thread.Sleep(5000);
            //red.Unregister(manager);
            //yellow.Register(manager);
            //manager.SimulateTimeOut(3);
            //Thread.Sleep(5000);
            //yellow.Unregister(manager);
            //green.Register(manager);
            //manager.SimulateTimeOut(5);


            Console.ReadKey();
        }
    }
}
