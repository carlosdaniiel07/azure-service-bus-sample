using System;
using System.Threading.Tasks;
using TemplateNetCore.Domain.Entities.Users;

namespace TemplateNetCore.Repository.Interfaces.Users
{
    public interface IUserRepository : IRepository<User>
    {
        Task<string> GetKeyById(Guid id);
    }
}
