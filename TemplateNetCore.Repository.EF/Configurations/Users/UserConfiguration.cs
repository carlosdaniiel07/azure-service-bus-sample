using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TemplateNetCore.Domain.Entities.Users;

namespace TemplateNetCore.Repository.EF.Configurations.Users
{
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("user");

            builder.HasIndex(entity => entity.Email)
                .IsUnique();

            builder.Property(entity => entity.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(entity => entity.Email)
                .HasColumnName("email")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(entity => entity.Password)
                .HasColumnName("password")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(entity => entity.Key)
                .HasColumnName("key")
                .HasColumnType("char(11)")
                .IsRequired();
        }
    }
}
