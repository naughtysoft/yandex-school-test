using System.Collections.Generic;
using System.Threading.Tasks;
using YandexTest.Core.RestBase.Repository;
using YandexTest.Data.OpenWeather.Model;

namespace YandexTest.Data.OpenWeather.Repository
{
    public class WeatherRepository : RestRepositoryBase
    {
        public async Task<WeatherResponse> GetWeather(WeatherRequest request)
        {
            var result = await Get<WeatherResponse>("http://api.openweathermap.org/data/2.5/weather", $"?{request}", new Dictionary<string, string>());

            return result;
        }
    }
}
