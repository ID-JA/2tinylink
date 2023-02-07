﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Domain.Common.BaseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entites.AppUser", b =>
                {
                    b.HasBaseType("Domain.Common.BaseEntity");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable("APP_USERS", (string)null);
                });

            modelBuilder.Entity("Domain.Entites.TinyLink", b =>
                {
                    b.HasBaseType("Domain.Common.BaseEntity");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AppUserId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ExpiredAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("LockHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("LockSalt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasIndex("AppUserId");

                    b.ToTable("TINY_LINKS", (string)null);
                });

            modelBuilder.Entity("Domain.Entites.TinyLink", b =>
                {
                    b.HasOne("Domain.Entites.AppUser", null)
                        .WithMany("TinyLinks")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("Domain.Entites.AppUser", b =>
                {
                    b.Navigation("TinyLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
