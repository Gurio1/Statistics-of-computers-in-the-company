using API_46731r.Domain.Entities.Identity;
using API_46731r.Domain.Exceptions;
using API_46731r.Domain.Repositories;
using API_46731r.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace API_46731r.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
    {
        private readonly MyProjectDbContext _context;

        public UserRepository(MyProjectDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> GetByEmailAsync(string email)
        {
            try
            {
                var user = await _context.Users.Where(x => x.Email == email).Include(x => x.Role).FirstOrDefaultAsync();

                if (user is null)
                {
                    throw new EmailNotFoundException($"User with email = '{email}' does not exist") ;
                }

                return user;
            }
            catch (Exception ex) when (ex is not EmailNotFoundException)
            {
                throw new Exception($"Could not retrieve entity : {ex.Message}");
            }
        }
    }
}
