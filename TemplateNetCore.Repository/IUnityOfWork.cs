using System.Threading.Tasks;
using TemplateNetCore.Repository.Interfaces.Users;
using TemplateNetCore.Repository.Interfaces.Transfers;

namespace TemplateNetCore.Repository
{
    public interface IUnityOfWork
    {
        IUserRepository UserRepository { get; }
        ITransferRepository TransferRepository { get; }

        void Commit();
        Task CommitAsync();
    }
}
