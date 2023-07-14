using AutoMapper;
using Homeo.Application.Enums;
using Homeo.Application.Interfaces;
using Homeo.DAL.Interfaces;
using Homeo.Domain;
using Homeo.DTOs.Request;
using Homeo.DTOs.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Homeo.Api.Controllers
{
    [Route("api/users/")]
    public class UserController : Controller {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _uok;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, [FromServices] IUnitOfWork uok, [FromServices] IMapper mapper) {
            _userRepository = userRepository;
            _uok = uok;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("post")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser([FromBody] UserRequestDTO request) {            
            if (!ModelState.IsValid) {
                var modelStateErrors = ModelState.SelectMany(ms => ms.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                var errorResponse = string.Join(',', modelStateErrors);
                return BadRequest(errorResponse);
            }

            if (request.Password != request.PasswordConfirmation) return BadRequest(ResponseErrorsEnum.MismatchPassword);
            if (_userRepository.FindUserByEmail(request.Email).Result != null) return BadRequest(ResponseErrorsEnum.UsernameAlreadyInUse);

            try {
                var mappedUser = _mapper.Map<User>(request);
                var createdUser = await _userRepository.AddUser(mappedUser, request.Password);

                if(createdUser.Succeeded) {
                    var response = new UserResponseDTO {
                        Email = request.Email,
                        Id = _userRepository.FindUserByEmail(request.Email).Id,
                        Name = request.Name
                    };

                    _uok.Commit();
                    return Created("api/users/post", response);
                } else {
                    var errors = createdUser.Errors.Select(e => e.Description);
                    var errorMessage = string.Join(',', errors);

                    return BadRequest(errorMessage);
                }

                return StatusCode((int) HttpStatusCode.InternalServerError);
            } catch (Exception exception) {
                _uok.Rollback();
                return StatusCode(((int)HttpStatusCode.InternalServerError));
            }           
        }
    }
}
