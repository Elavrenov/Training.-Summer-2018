﻿using System.Collections.Generic;

namespace No2
{
    public class WeatherData : IObservable
    {
        private List<IObserver> observers;

        public WeatherInfo WeatherInfo { get; private set; }

        public WeatherData()
        {
            observers = new List<IObserver>();
            WeatherInfo = new WeatherInfo();
        }

        public void Notify(IObservable sender, WeatherInfo info)
        {
            foreach (var item in observers)
            {
                item.Update(this, info);
            }
        }

        public void Register(IObserver observer) => observers.Add(observer);

        public void Unregister(IObserver observer) => observers.Remove(observer);

        public void MeasurementsChange(int temperature, int humidity, int pressure)
        {
            WeatherInfo.Humidity = humidity;
            WeatherInfo.Temperature = temperature;
            WeatherInfo.Pressure = pressure;
            Notify(this, WeatherInfo);
        }
    }
}
