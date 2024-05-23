using CovadisAPI.Entities;
using DemoCovadis.Entities;
using Microsoft.EntityFrameworkCore;

namespace CovadisAPI.Context
{
    public class LeenAutoDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Auto> Autos { get; set; }

        public DbSet<Rit> Ritten { get; set; }

        public LeenAutoDbContext(DbContextOptions<LeenAutoDbContext> options) : base(options)
        {

        }
    }
}
