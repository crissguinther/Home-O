using Homeo.Application.Interfaces;
using Homeo.DTOs.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Homeo.Api.Controllers {
    [Route("api/users/")]
    public class UserController : Controller {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("post")]
        [AllowAnonymous]
        public IActionResult RegisterUser(AddUserRequestDTO request) {
            return Ok();
        }
    }
}
