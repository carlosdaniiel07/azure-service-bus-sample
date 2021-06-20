using System.Threading.Tasks;
using TemplateNetCore.Repository.EF.Repositories.Transfers;
using TemplateNetCore.Repository.EF.Repositories.Users;
using TemplateNetCore.Repository.Interfaces.Transfers;
using TemplateNetCore.Repository.Interfaces.Users;

namespace TemplateNetCore.Repository.EF
{
    public class UnitOfWork : IUnityOfWork
    {
        private readonly ApplicationDbContext context;

        private UserRepository userRepository;
        private TransferRepository transferRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(context);
                }

                return userRepository;
            }
        }

        public ITransferRepository TransferRepository
        {
            get
            {
                if (transferRepository == null)
                {
                    transferRepository = new TransferRepository(context);
                }

                return transferRepository;
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
