using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TemplateNetCore.Domain.Dto.Transfers;
using TemplateNetCore.Domain.Entities.Transfers;
using TemplateNetCore.Domain.Enums.Transfers;
using TemplateNetCore.Domain.Interfaces.Users;
using TemplateNetCore.Repository;

namespace TemplateNetCore.Service.Transfers
{
    public class TransferQueueConsumerService : IHostedService
    {
        private static QueueClient queueClient;

        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<TransferQueueConsumerService> _logger;

        public TransferQueueConsumerService(IServiceScopeFactory serviceScopeFactory, ILogger<TransferQueueConsumerService> logger, IConfiguration configuration)
        {
            queueClient = new QueueClient(configuration.GetValue<string>("AzureServiceBus"), "transfers");

            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando leitura da fila...");
            
            ProcessMessageHandler();
            
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Parando leitura da fila...");

            await queueClient.CloseAsync();
            await Task.CompletedTask;
        }

        private void ProcessMessageHandler()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false,
            };

            queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        private async Task ProcessMessagesAsync(Message message, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Processando mensagem da fila...");

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var unityOfWork = scope.ServiceProvider.GetRequiredService<IUnityOfWork>();
                var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
                
                var messageContent = Encoding.UTF8.GetString(message.Body);
                var postTransferDto = JsonSerializer.Deserialize<PostTransferDto>(messageContent);
                var transfer = new Transfer
                {
                    Value = postTransferDto.Value,
                    From = await userService.GetByKey(postTransferDto.FromKey),
                    To = await userService.GetByKey(postTransferDto.ToKey),
                    Status = TransferStatus.Done
                };

                await unityOfWork.TransferRepository.AddAsync(transfer);
                await unityOfWork.CommitAsync();
            }

            await queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            _logger.LogError("Erro ao realizar leitura da fila");
            return Task.CompletedTask;
        }
    }
}
