using API_46731r.Domain.Entities;
using API_46731r.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace API_46731r.Infrastructure
{
    public class MyProjectDbContext : DbContext
    {
        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options) : base(options) 
        {
           // Database.EnsureDeleted();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Computer> Computers { get; set; }

        public DbSet<ComputerCharacteristics> ComputerCharacteristics { get; set; }

        public DbSet<ApplicationRole> Roles { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }
    }
}

