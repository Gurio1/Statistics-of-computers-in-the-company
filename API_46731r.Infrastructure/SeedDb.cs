using API_46731r.Domain.Entities;
using API_46731r.Domain.Entities.ComputerState;
using API_46731r.Domain.Entities.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace API_46731r.Infrastructure
{
    public static class SeedDb
    {
        public static void Init(this IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<MyProjectDbContext>();

            var role = new ApplicationRole()
            {
                Name = "Administrator",
                Force = 0,
            };


            var user = new ApplicationUser()
            {
                FirstName = "Andrey",
                LastName = "Iliev",
                Email = "a.iliev@unibit.bg",
                HashedPassword = "1234qwe",
                RoleId = 1,
            };

            var comp = new Computer()
            {
                HostName = "U1-R301-01",
                InventoryNumber = 34323,
                MAC = "43-ew-32-er-3r-5T",
                CheckedOn = new List<ComputerCheckedOn>()
                {
                    new ComputerCheckedOn()
                    {
                    CheckedOn = DateTime.Now,
                    ComputerId = 1,
                    UserId = 1
                    }
                },
                ModifiedOn = new List<ComputerModifiedOn>()
                {
                    new ComputerModifiedOn()
                    {
                    CheckedOn = DateTime.Now,
                    ComputerId = 1,
                    UserId = 1
                    }
                },
                State = 0,
                Characteristics = new ComputerCharacteristics
                {
                    ComputerId = 1,
                    MotherBoard = "Test",
                    Processor = "Razen",
                    Storage = 512,
                    RAM = 8,
                }

            };

            //context.Roles.Add(role);
            //context.SaveChanges();

            //context.Users.Add(user);
            //context.SaveChanges();

            context.Computers.Add(comp);
            context.SaveChanges();

        }


    }
}
