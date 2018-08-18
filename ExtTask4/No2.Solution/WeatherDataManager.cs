using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No2.Solution
{
    public class WeatherDataManager
    {
        public event EventHandler<NewWeatherChangeEventArgs> NewWeatherChange;

        public void WeatherChange(int temperature, int humidity, int pressure)
        {
            OnNewWeatherChange(new NewWeatherChangeEventArgs(temperature,humidity,pressure));
        }

        protected virtual void OnNewWeatherChange(NewWeatherChangeEventArgs e)
        {
            var temp = NewWeatherChange;
            temp?.Invoke(this, e);
        }
    }
}
