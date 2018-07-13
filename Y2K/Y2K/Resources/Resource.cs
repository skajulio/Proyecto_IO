using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Y2K.Models;
using Y2K.TransferObject;

namespace Y2K.Resources
{
    public static class Resource
    {
        private static int _id;
        /// <summary>
        /// Carga las ciudades a la BD
        /// </summary>
        public static void GetCity()
        {
            using (Y2kContext context = new Y2kContext())
            {
                if (!context.City.Any())
                {
                    string content = Task.Run(GetDate).Result;
                    List<Models.City> cities = JsonConvert.DeserializeObject<List<Models.City>>(content);
                    foreach (var c in cities)
                    {
                        Models.City city = new Models.City();
                        city.IdExternal = c.Id;
                        city.Name = c.Name;
                        city.Country = c.Country;
                        context.City.Add(city);
                    }
                    context.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Guarda el clima de una ciudad en especifico 
        /// </summary>
        /// <param name="id"></param>
        public static Models.Weather GetWeather(int id)
        {
            _id = id;
            Models.Weather weather = new Models.Weather();
            string content = Task.Run(GetWeather).Result;
            WeatherAPI weathers = JsonConvert.DeserializeObject<WeatherAPI>(content);
            weather.IdExternal = weathers.weather[0].id;
            weather.Main = weathers.weather[0].main;
            weather.Description = weathers.weather[0].description;
            weather.Icon = weathers.weather[0].icon;
            weather.cod = weathers.cod;
            using (Y2kContext context = new Y2kContext())
            {
                context.Weather.Add(weather);
                context.SaveChanges();
            }
            return weather;
        }
        /// <summary>
        /// Obtine las ciudades de la Web API
        /// </summary>
        /// <returns>Task<string></returns>
        private static async Task<string> GetDate()
        {
            string url = "http://middleware-neoris.s3-website-us-west-1.amazonaws.com";

            HttpClient Client = new HttpClient();

            string content = await Client.GetStringAsync(url);

            return content;
        }
        /// <summary>
        /// Obtine el clima de una ciudad
        /// </summary>
        /// <param name="Id">Id de la ciudad a buscar</param>
        /// <returns> Task<string></returns>
        private static async Task<string> GetWeather()
        {
            string url = $"https://samples.openweathermap.org/data/2.5/weather?id={_id}&APPID=4b0bd706f7de426da4c731e528484aef";

            HttpClient Client = new HttpClient();

            string content = await Client.GetStringAsync(url);

            return content;
        }
    }
}