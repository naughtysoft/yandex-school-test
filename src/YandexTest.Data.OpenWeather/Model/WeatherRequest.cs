using System;
using System.Collections.Generic;
using System.Text;

namespace YandexTest.Data.OpenWeather.Model
{
    public class WeatherRequest
    {
        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public string Units { get; } = "metric";

        public string AppId { get; } = "b6c6a0e8f7dd578e87b4445b29588c06";

        public override string ToString()
        {
            var result = $"lat={Latitude}&lon={Longitude}&appid={AppId}&units={Units}";

            return result;
        }
    }
}
