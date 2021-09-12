using System;
using System.Text;
using Azure.Messaging.ServiceBus;
using Core.Settings;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Core
{
    public class ServiceBusClient : IServiceBusClient
    {
        private string _connectionString;
        public ServiceBusClient(IOptions<ServiceBusSettings> serviceBusSettings)
        {
            _connectionString = serviceBusSettings.Value.PrimaryConnectionString;
        }

        public QueueClient CreateClient()
        {
            return new QueueClient(new ServiceBusConnectionStringBuilder(_connectionString), ReceiveMode.ReceiveAndDelete,RetryPolicy.Default);
        }
    }
}
