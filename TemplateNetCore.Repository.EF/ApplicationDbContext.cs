using Microsoft.EntityFrameworkCore;
using System;
using TemplateNetCore.Domain.Entities.Transfers;
using TemplateNetCore.Domain.Entities.Users;
using TemplateNetCore.Repository.EF.Configurations.Transfers;
using TemplateNetCore.Repository.EF.Configurations.Users;

namespace TemplateNetCore.Repository.EF
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<User> Users{ get; set; }
        public virtual DbSet<Transfer> Transfers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TransferConfiguration());
        }
    }
}
