using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TemplateNetCore.Domain.Dto.Transfers;
using TemplateNetCore.Domain.Interfaces.Transfers;

namespace TemplateNetCore.Service.Transfers
{
    public class TransferQueueService : ITransferQueueService
    {
        private readonly string _serviceBusConnectionString;

        public TransferQueueService(IConfiguration configuration)
        {
            _serviceBusConnectionString = configuration.GetValue<string>("AzureServiceBus");
        }

        public async Task Add(PostTransferDto postTransferDto)
        {
            var queueName = "transfers";
            var client = new QueueClient(_serviceBusConnectionString, queueName, ReceiveMode.PeekLock);
            var messageBody = JsonSerializer.Serialize(postTransferDto);
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));

            await client.SendAsync(message);
            await client.CloseAsync();
        }
    }
}
