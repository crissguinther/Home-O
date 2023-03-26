using Homeo.Application.Interfaces;
using Homeo.Data.Interfaces;
using Homeo.Domain;
using Homeo.DTOs.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Homeo.Application.Repositories {
    public class UserRepository : IUserRepository {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUnitOfWork _uok;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager, [FromServices] IUnitOfWork uok) {
            _userManager = userManager;
            _signInManager = signInManager;
            _uok = uok;
        }

        public Task<UserResponseDTO> AddUser() {
            throw new NotImplementedException();
        }
    }
}
