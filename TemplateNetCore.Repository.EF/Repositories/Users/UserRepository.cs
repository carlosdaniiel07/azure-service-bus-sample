using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TemplateNetCore.Domain.Entities.Users;
using TemplateNetCore.Repository.Interfaces.Users;

namespace TemplateNetCore.Repository.EF.Repositories.Users
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<string> GetKeyById(Guid id)
        {
            return await dbSet
                .Where(user => user.Id == id)
                .Select(user => user.Key)
            .FirstOrDefaultAsync();
        }
    }
}
