﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TemplateNetCore.Repository.EF;

namespace TemplateNetCore.Repository.EF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TemplateNetCore.Domain.Entities.Transfers.Transfer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<Guid>("FromId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("from_id");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint")
                        .HasColumnName("status");

                    b.Property<Guid>("ToId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("to_id");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(11,2)")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("transfer");
                });

            modelBuilder.Entity("TemplateNetCore.Domain.Entities.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("char(11)")
                        .HasColumnName("key");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("user");
                });

            modelBuilder.Entity("TemplateNetCore.Domain.Entities.Transfers.Transfer", b =>
                {
                    b.HasOne("TemplateNetCore.Domain.Entities.Users.User", "From")
                        .WithMany()
                        .HasForeignKey("FromId")
                        .HasConstraintName("FK_transfer_from_id_user")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TemplateNetCore.Domain.Entities.Users.User", "To")
                        .WithMany()
                        .HasForeignKey("ToId")
                        .HasConstraintName("FK_transfer_to_id_user")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("From");

                    b.Navigation("To");
                });
#pragma warning restore 612, 618
        }
    }
}
