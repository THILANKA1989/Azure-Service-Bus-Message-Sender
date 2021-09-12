using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IServiceBusClient
    {
        QueueClient CreateClient();
    }
}
