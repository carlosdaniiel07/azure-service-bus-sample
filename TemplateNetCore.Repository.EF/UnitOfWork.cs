using System.Threading.Tasks;
using TemplateNetCore.Repository.EF.Repositories.Users;
using TemplateNetCore.Repository.Interfaces.Users;

namespace TemplateNetCore.Repository.EF
{
    public class UnitOfWork : IUnityOfWork
    {
        private readonly ApplicationDbContext context;

        private UserRepository _userRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(context);
                }

                return _userRepository;
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
