using API_46731r.Contracts;
using API_46731r.Domain.Entities.Identity;
using API_46731r.Domain.Exceptions;
using API_46731r.Domain.Exceptions.Authentication;
using API_46731r.Domain.Repositories;
using API_46731r.Services.Abstractions.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace API_46731r.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<ApplicationUser> _hasher;

        public AuthenticationService(IUserRepository userRepository, IPasswordHasher<ApplicationUser> hasher)
        {
            _userRepository = userRepository;
            _hasher = hasher;
        }

        public async Task<ApplicationUser> LogIn(ApplicationUserViewModel userVM)
        {
            try
            {
                var user = await _userRepository.GetByEmailAsync(userVM.Email);
                var hashResult = _hasher.VerifyHashedPassword(user, user.HashedPassword, userVM.Password);

                if (hashResult != PasswordVerificationResult.Success)
                {
                    throw new InvalidPasswordExeption("Invalid password");
                }

                return user;
            }
            catch (EmailNotFoundException ex)
            {
                throw new InvalidEmailExeption("Invalid email");
            }
        }
    }
}
