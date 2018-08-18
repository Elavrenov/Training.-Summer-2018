using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No2.Solution
{
    public class CurrentConditionReport
    {
        public void Register(WeatherDataManager manager)
        {
            manager.NewWeatherChange += CurrentConditionReportMsg;
        }

        public void Unregister(WeatherDataManager manager)
        {
            manager.NewWeatherChange -= CurrentConditionReportMsg;
        }

        private void CurrentConditionReportMsg(object sender, NewWeatherChangeEventArgs eventArgs)
        {
            Console.WriteLine($"Current condition was changed");
        }
    }
}
