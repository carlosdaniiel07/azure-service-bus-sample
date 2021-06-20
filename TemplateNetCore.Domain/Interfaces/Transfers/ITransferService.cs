using System;
using System.Threading.Tasks;
using TemplateNetCore.Domain.Dto.Transfers;

namespace TemplateNetCore.Domain.Interfaces.Transfers
{
    public interface ITransferService
    {
        Task Save(Guid userId, PostTransferDto postTransferDto);
    }
}
