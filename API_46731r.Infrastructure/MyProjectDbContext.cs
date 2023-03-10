using API_46731r.Domain.Entities;
using API_46731r.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using API_46731r.Domain.Entities.ComputerState;
using Microsoft.AspNetCore.Identity;

namespace API_46731r.Infrastructure
{
    public class MyProjectDbContext : DbContext
    {
        private readonly IPasswordHasher<ApplicationUser> _hasher;

        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options,IPasswordHasher<ApplicationUser> hasher) : base(options)
        {
            _hasher = hasher;
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region SeedDB

            var user = new ApplicationUser()
                { Id = 1, RoleId = 1, Email = "a.iliev@unibit.bg", FirstName = "Andrey", LastName = "Iliev" };
            
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole() { Id = 1, Name = "Administrator", Force = 0 });
            modelBuilder.Entity<ApplicationUser>().HasData
                (new ApplicationUser() { Id = 1,RoleId = 1,Email = "a.iliev@unibit.bg",
                                         FirstName = "Andrey",LastName = "Iliev",HashedPassword = _hasher.HashPassword(user, "123qwe")});
            modelBuilder.Entity<Building>().HasData(
                new Building { Id = 1,Name = "Унибит-1"},
                new Building { Id = 2,Name = "Унибит-2" }
            );
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1,Name = "101",BuildingId = 1},
                new Room { Id = 2,Name = "214",BuildingId = 1},
                new Room { Id = 3,Name = "316",BuildingId = 2}
            );
            modelBuilder.Entity<ComputerCharacteristics>().HasData(
                new ComputerCharacteristics()
                {
                    Id = 1, RAM = 8, Storage = 512, Processor = "Intel i5", MotherBoard = "Test"

                });
            modelBuilder.Entity<Computer>().HasData(
                new Computer()
                {
                    Id = 1, ComputerCharacteristicsId = 1, RoomId = 1, HostName = "U1-101-01",
                    InventoryNumber = 435122,
                    Mac = "4t-45-4t-34"
                });
            modelBuilder.Entity<ComputerCheckedOn>().HasData(
                new List<ComputerCheckedOn>()
                {
                    new ComputerCheckedOn(){ Id = 1,CheckedOn = DateTime.Now, UserId = 1,ComputerId = 1}

                });
            modelBuilder.Entity<ComputerModifiedOn>().HasData(
                new List<ComputerModifiedOn>()
                {
                    new ComputerModifiedOn(){ Id = 1,CheckedOn = DateTime.Now, UserId = 1,ComputerId = 1}

                });

            #endregion
            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public DbSet<ComputerCharacteristics> ComputerCharacteristics { get; set; }

        public DbSet<ApplicationRole> Roles { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }
    }
}

