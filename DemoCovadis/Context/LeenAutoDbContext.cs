using CovadisAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CovadisAPI.Context
{
    public class LeenAutoDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public LeenAutoDbContext(DbContextOptions<LeenAutoDbContext> options) : base(options)
        {

        }
    }
}
