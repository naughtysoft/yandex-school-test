using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexTest.Business.Module.Contract;
using YandexTest.Data.Nominatim.Model;
using YandexTest.Data.Nominatim.Repository;
using YandexTest.Data.OpenWeather.Model;
using YandexTest.Data.OpenWeather.Repository;
using YandexTest.Data.Telegram.Repository;

namespace YandexTest.Business.Module
{
    public class TelegramModule
    {
        private readonly WeatherRepository _weatherRepository;
        private readonly TelegramMessageRepository _telegramMessageRepository;
        private readonly NominatimSearchRepository _nominatimSearchRepository;

        public TelegramModule(
            WeatherRepository weatherRepository,
            TelegramMessageRepository telegramMessageRepository,
            NominatimSearchRepository nominatimSearchRepository)
        {
            _weatherRepository = weatherRepository;
            _telegramMessageRepository = telegramMessageRepository;

            _nominatimSearchRepository = nominatimSearchRepository;
        }


        public async Task<object> ProcessWebhook(MessageContract contract)
        {
            var message = "";

            try
            {
                if (contract.Message.Location != null)
                {
                    var userLocation = contract.Message.Location;
                    var r = await _weatherRepository.GetWeather(new WeatherRequest { Latitude = userLocation.Latitude, Longitude = userLocation.Longitude });

                    message = FormatMessage(r.Main.Temp, r.Wind.Speed);
                }
                else
                {
                    var geocodingResult = await _nominatimSearchRepository.GetPoints(new NominatimSearchRequest { SearchText = contract.Message.Text });

                    var places = geocodingResult.Where(x => x.ClassName == "place");

                    if (!places.Any())
                        throw new Exception();

                    var placeLocation = places.FirstOrDefault();

                    var r = await _weatherRepository.GetWeather(new WeatherRequest { Latitude = placeLocation.Latitude, Longitude = placeLocation.Longitude });

                    message = FormatMessage(r.Main.Temp, r.Wind.Speed);
                }
            }
            catch
            {
                message = "К сожалению Я не смог определить температуру рядом с Вами";
            }
            finally
            {
                await _telegramMessageRepository.SendMessage(contract.Message.Chat.Id, message);
            }
            //"*bold text*_italic text_[text](URL)`inline fixed-width code````pre - formatted fixed-width code block```");

            return true;
        }

        private static string FormatMessage(double temp, double speed)
        {
            return $"*Погода рядом с вами:*\nТемпература: `{temp}℃`\nСкорость ветра: `{speed}м/с`";
        }
    }
}
