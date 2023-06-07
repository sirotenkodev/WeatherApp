using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp
{
    [Route("/")]
    public class WeatherController : Controller
    {

        public WeatherService weatherService { get; set; }
        public IConfiguration AppSetting { get; }
        private string ApiKey;
        public WeatherController()
        {
            weatherService = new WeatherService();
            AppSetting = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("apikey.json")
            .Build();
            ApiKey = AppSetting["ApiKey"];
        }

        [Route("/")]
        [Route("/index")]
        [Route("/weather")]
        [HttpGet]
        public IActionResult Weather()
        {
            string uri = "http://api.openweathermap.org/data/2.5/weather?q=Omsk&units=metric&appid=" + ApiKey;
            WeatherData results = weatherService.GetWeatherData(uri).GetAwaiter().GetResult();
            return View(results);
        }

        [HttpPost]
        public IActionResult Weather(string city)
        {
            string uri = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&units=metric&appid=" + ApiKey;
            WeatherData results = weatherService.GetWeatherData(uri).GetAwaiter().GetResult();
            return View(results);
        }
    }
}
