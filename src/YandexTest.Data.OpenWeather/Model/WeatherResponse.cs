using Newtonsoft.Json;
using System.Collections.Generic;

namespace YandexTest.Data.OpenWeather.Model
{
    public class WeatherResponse
    {
        public List<WeatherResponseWeather> Weather { get; set; }

        public WeatherResponseMain Main { get; set; }

        public WeatherResponseCloud Clouds { get; set; }

        public WeatherReponseWind Wind { get; set; }
    }

    public class WeatherResponseWeather
    {
        public long Id { get; set; }

        public string Main { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }
    }

    public class WeatherResponseMain
    {
        public double Temp { get; set; }

        public double Pressure { get; set; }

        public double Humidity { get; set; }

        [JsonProperty(PropertyName = "temp_min")]
        public double TempMin { get; set; }

        [JsonProperty(PropertyName = "temp_max")]
        public double TempMax { get; set; }
    }

    public class WeatherReponseWind
    {
        public double Speed { get; set; }

        public double Deg { get; set; }
    }

    public class WeatherResponseCloud
    {
        public double All { get; set; }
    }
}
