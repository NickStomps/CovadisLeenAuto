using CovadisAPI.Entities;
using DemoCovadis.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CovadisAPI.Context
{
    public class LeenAutoDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Auto> Autos { get; set; }

        public DbSet<Role> Roles { get; set; }  

        public DbSet<Rit> Ritten { get; set; }


        public LeenAutoDbContext(DbContextOptions<LeenAutoDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 2,
                    Naam = "User",
                    Email = "user@example.com",
                    Wachtwoord = "UserPassword"
                });

            modelBuilder.Entity<User>().HasData(
                 new User
                 {
                     Id = 1,
                     Naam = "Admin",
                     Email = "admin@example.com",
                     Wachtwoord = "AdminPassword"
                 });

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Naam = "Admin"
                },
                new Role
                {
                    Id = 2,
                    Naam = "User"
                });
        }
    }
}