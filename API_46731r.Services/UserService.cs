using API_46731r.Contracts;
using API_46731r.Domain.Entities.Identity;
using API_46731r.Domain.Repositories;
using API_46731r.Services.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace API_46731r.Services
{
    public class UserService : GenericService<IUserRepository, ApplicationUser>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository repository) : base(repository)
        {
            _userRepository = repository;
        }

        public async Task<ApplicationUser> GetByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }
    }
}
