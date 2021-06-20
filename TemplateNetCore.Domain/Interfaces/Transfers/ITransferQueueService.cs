using System.Threading.Tasks;
using TemplateNetCore.Domain.Dto.Transfers;

namespace TemplateNetCore.Domain.Interfaces.Transfers
{
    public interface ITransferQueueService
    {
        Task Add(PostTransferDto postTransferDto);
    }
}
