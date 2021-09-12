using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBusAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IServiceBusClient _serviceBusClient;
        public WeatherForecastController(IServiceBusClient serviceBusClient)
        {
            _serviceBusClient = serviceBusClient;
        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public string Get()
        {
            var client = _serviceBusClient.CreateClient();
            var message = new
            {
                firstname = "Azure Bus",
                lastname = "Contact",
                email = "azuresbus@gmail.com"
            };

            var json = JsonConvert.SerializeObject(message);
            //Convert
            client.SendAsync(new Message(System.Text.Encoding.UTF8.GetBytes(json)));
            //client.Me
            return json;
        }
    }
}
