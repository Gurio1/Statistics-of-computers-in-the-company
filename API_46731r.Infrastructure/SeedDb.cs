using API_46731r.Domain.Entities;
using API_46731r.Domain.Entities.ComputerState;
using API_46731r.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API_46731r.Infrastructure
{
    public static class SeedDb
    {
        public static void Init(this IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<MyProjectDbContext>();

            //var role = new ApplicationRole()
            //{
            //    Name = "Administrator",
            //    Force = 0,
            //};


            //var user = new ApplicationUser()
            //{
            //    FirstName = "Andrey",
            //    LastName = "Iliev",
            //    Email = "a.iliev@unibit.bg",
            //    HashedPassword = "1234qwe",
            //    RoleId = 1,
            //};

            var comp = new Computer()
            {
                HostName = "U1-R301-01",
                InventoryNumber = 234235,
                Mac = "Test",
                CheckedOn = new List<ComputerCheckedOn>()
                {
                    new ComputerCheckedOn()
                    {
                    CheckedOn = DateTime.Now,
                    UserId = 1
                    }
                },
                ModifiedOn = new List<ComputerModifiedOn>()
                {
                    new ComputerModifiedOn()
                    {
                    CheckedOn = DateTime.Now,
                    UserId = 1
                    }
                },
                State = 0,
                Characteristics = new ComputerCharacteristics
                {
                    MotherBoard = "Test",
                    Processor = "Razen",
                    Storage = 512,
                    RAM = 8,
                }
            };



            //var room = new Room()
            //{
            //    Name = "101",
            //    Computers = new List<Computer>() { comp }
            //};

            //var building = new Building()
            //{
            //    Name = "Унибит-1",
            //    Rooms = new List<Room>() { room }
            //};

            var a = context.Rooms.Include(c =>c.Computers).Where(r => r.Name == "101").FirstOrDefault();
            a.Computers.Add(comp);

            context.Rooms.Update(a);
            context.SaveChanges();


            //context.Roles.Add(role);
            //context.SaveChanges();

            //context.Users.Add(user);
            //context.SaveChanges();

            //context.Buildings.Add(building);
            //context.SaveChanges();

        }


    }
}
