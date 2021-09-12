using Azure.Messaging.ServiceBus;
using Core;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;

namespace MessageCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            new ServiceTrigger().Trigger();
        }
    }

    public class ServiceTrigger
    {

        public void Trigger()
        {
            Console.WriteLine("Writing message.....");
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


            Console.ReadLine();
        }

        private IServiceBusClient _serviceBusClient;
        public ServiceTrigger(IServiceBusClient serviceBusClient)
        {
            _serviceBusClient = serviceBusClient;
        }

       
    }

}
