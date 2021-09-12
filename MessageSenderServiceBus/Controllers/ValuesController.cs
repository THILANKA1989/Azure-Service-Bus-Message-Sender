using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MessageSenderServiceBus.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IServiceBusClient _serviceBusClient;
        public ValuesController(IServiceBusClient serviceBusClient)
        {
            _serviceBusClient = serviceBusClient;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
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

            return new string[] { "Message", json };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
