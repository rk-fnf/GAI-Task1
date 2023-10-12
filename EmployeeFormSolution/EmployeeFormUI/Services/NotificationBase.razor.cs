using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Components;

namespace EmployeeFormUI.Services
{
    public class NotificationBase : ComponentBase
    {
        public List<string> messages = new List<string>();
        private string connectionString = "Endpoint=sb://servicebustask.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=NHoLFg8l+gxknbwo3EjS65wL3Wxmiechc+ASbKVhqgI=";
        private string queueName = "cosomosinfo";

        public async Task RetrieveMessages()
        {
            try
            {
                await using var client = new ServiceBusClient(connectionString);
                var receiver = client.CreateReceiver(queueName);

                while (true)
                {
                    ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync();

                    if (message != null)
                    {
                        messages.Add(message.Body.ToString());
                        await receiver.CompleteMessageAsync(message);
                    }
                    else
                    {
                        // No more messages in the queue
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                messages.Add($"Error: {ex.Message}");
            }
        }
    }
}
