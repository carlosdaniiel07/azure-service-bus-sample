using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TemplateNetCore.Domain.Entities.Transfers;

namespace TemplateNetCore.Repository.EF.Configurations.Transfers
{
    public class TransferConfiguration : BaseEntityConfiguration<Transfer>
    {
        public override void Configure(EntityTypeBuilder<Transfer> builder)
        {
            base.Configure(builder);

            builder.ToTable("transfer");

            builder.Property(entity => entity.Value)
                .HasColumnName("value")
                .HasColumnType("decimal(11,2)");

            builder.Property(entity => entity.FromId)
                .HasColumnName("from_id")
                .IsRequired();

            builder.Property(entity => entity.ToId)
                .HasColumnName("to_id")
                .IsRequired();

            builder.Property(entity => entity.Status)
                .HasColumnName("status")
                .IsRequired();

            builder.HasOne(entity => entity.From)
                .WithMany()
                .HasForeignKey(entity => entity.FromId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired()
                .HasConstraintName("FK_transfer_from_id_user");

            builder.HasOne(entity => entity.To)
                .WithMany()
                .HasForeignKey(entity => entity.ToId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired()
                .HasConstraintName("FK_transfer_to_id_user");
        }
    }
}
