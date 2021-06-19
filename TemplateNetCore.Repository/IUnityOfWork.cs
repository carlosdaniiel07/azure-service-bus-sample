using System.Threading.Tasks;
using TemplateNetCore.Repository.Interfaces.Users;

namespace TemplateNetCore.Repository
{
    public interface IUnityOfWork
    {
        IUserRepository UserRepository { get; }
        
        void Commit();
        Task CommitAsync();
    }
}
