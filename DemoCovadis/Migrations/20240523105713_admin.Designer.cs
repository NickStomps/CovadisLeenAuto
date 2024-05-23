﻿// <auto-generated />
using CovadisAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoCovadis.Migrations
{
    [DbContext(typeof(LeenAutoDbContext))]
    [Migration("20240523105713_admin")]
    partial class admin
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("CovadisAPI.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Wachtwoord")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Email = "user@example.com",
                            Naam = "User",
                            Wachtwoord = "UserPassword"
                        },
                        new
                        {
                            Id = 1,
                            Email = "admin@example.com",
                            Naam = "Admin",
                            Wachtwoord = "AdminPassword"
                        });
                });

            modelBuilder.Entity("DemoCovadis.Entities.Auto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("aankomstTijd")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("beginAdres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("beginStandKm")
                        .HasColumnType("INTEGER");

                    b.Property<int>("bestuurderId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("eindAdres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("eindStandKm")
                        .HasColumnType("INTEGER");

                    b.Property<string>("kenteken")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("vertrekTijd")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("bestuurderId");

                    b.ToTable("Autos");
                });

            modelBuilder.Entity("DemoCovadis.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Naam = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Naam = "User"
                        });
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("DemoCovadis.Entities.Auto", b =>
                {
                    b.HasOne("CovadisAPI.Entities.User", "bestuurder")
                        .WithMany()
                        .HasForeignKey("bestuurderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bestuurder");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("DemoCovadis.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CovadisAPI.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
