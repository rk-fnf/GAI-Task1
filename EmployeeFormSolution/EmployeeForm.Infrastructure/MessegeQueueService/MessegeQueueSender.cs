using Azure.Messaging.ServiceBus;
using EmployeeForm.Application.Contracts.MessegeQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeForm.Infrastructure.MessegeQueueService
{
    public class MessegeQueueSender:IMessegeQueueSender
    {
        public string ConnectionToQueue = "Endpoint=sb://servicebustask.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=NHoLFg8l+gxknbwo3EjS65wL3Wxmiechc+ASbKVhqgI=";
        public async Task InsertTextToMessegeQueue(string content)
        {
            var client = new ServiceBusClient(ConnectionToQueue);
            var sender = client.CreateSender("cosomosinfo");
            var messege = new ServiceBusMessage(content);
            await sender.SendMessageAsync(messege);
        }
    }
}
