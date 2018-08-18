using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No2.Solution.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherDataManager dataManager = new WeatherDataManager();

            CurrentConditionReport sub1 = new CurrentConditionReport();
            ForeCastReport sub2 = new ForeCastReport();
            StatisticReport sub3 = new StatisticReport(); ;

            sub1.Register(dataManager);

            dataManager.WeatherChange(100, 200, 300);

            sub2.Register(dataManager);
            sub3.Register(dataManager);

            dataManager.WeatherChange(100,200,300);

            sub2.Unregister(dataManager);
            dataManager.WeatherChange(100, 200, 300);

            System.Console.ReadKey();
        }
    }
}
