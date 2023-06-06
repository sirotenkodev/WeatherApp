using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class WeatherController : Controller
    {

        public WeatherService weatherService { get; set; }

        public WeatherController()
        {
            weatherService = new WeatherService();
        }
        public IActionResult Weather()
        {
            string uri = "http://api.openweathermap.org/data/2.5/weather?q=Omsk&units=metric&appid=01351d08df9240a33b4bf6cbd923b7dd";
            WeatherData results = weatherService.GetWeatherData(uri).Result;
            return View(results);
        }
    }
}
