using TemplateNetCore.Domain.Entities.Transfers;
using TemplateNetCore.Repository.Interfaces.Transfers;

namespace TemplateNetCore.Repository.EF.Repositories.Transfers
{
    public class TransferRepository : Repository<Transfer>, ITransferRepository
    {
        public TransferRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
