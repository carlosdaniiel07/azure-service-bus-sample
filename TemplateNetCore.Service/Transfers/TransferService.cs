using System;
using System.Threading.Tasks;
using TemplateNetCore.Domain.Dto.Transfers;
using TemplateNetCore.Domain.Interfaces.Transfers;
using TemplateNetCore.Domain.Interfaces.Users;
using TemplateNetCore.Service.Exceptions;

namespace TemplateNetCore.Service.Transfers
{
    public class TransferService : ITransferService
    {
        private readonly IUserService _userService;
        private readonly ITransferQueueService _transferQueueService;

        public TransferService(IUserService userService, ITransferQueueService transferQueueService)
        {
            _userService = userService;
            _transferQueueService = transferQueueService;
        }

        public async Task Save(Guid id, PostTransferDto postTransferDto)
        {
            var fromKey = await _userService.GetKeyById(id);
            var toKey = (await _userService.GetByKey(postTransferDto.ToKey)).Key;
            
            if (fromKey == null)
            {
                throw new NotFoundException("Usuáro de origem não encontrado");
            }

            if (toKey == null)
            {
                throw new NotFoundException($"Chave de destino ({toKey}) não encontrada");
            }

            await _transferQueueService.Add(new PostTransferDto
            {
                Value = postTransferDto.Value,
                FromKey = fromKey,
                ToKey = toKey,
            });
        }
    }
}
