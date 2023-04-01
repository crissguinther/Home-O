using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Homeo.Api.Controllers;
using Homeo.Application.Enums;
using Homeo.Application.Interfaces;
using Homeo.Data.Interfaces;
using Homeo.Domain;
using Homeo.DTOs.Request;
using Homeo.DTOs.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Xunit;

namespace Homeo.Tests.Controllers {
    public class UserControllerTests {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserController _sut;
        private readonly IMapper _mapper;

        public UserControllerTests() {
            _userRepository = A.Fake<IUserRepository>();
            _unitOfWork = A.Fake<IUnitOfWork>();
            _mapper = A.Fake<IMapper>();

            _sut = new UserController(_userRepository, _unitOfWork, _mapper);
        }

        [Fact]
        public void UserController_RegisterUser_Should_Return_Created() {
            //Arrange
            var user = A.Fake<UserRequestDTO>();
            user.Email = "email@email.com";
            user.Password = "@ABc12aeioC!";
            user.PasswordConfirmation = "@ABc12aeioC!";
            user.AccountType = 2;
            user.Name = "Jane Doe";

            A.CallTo(() => _userRepository.FindUserByEmail(A<string>._)).Returns(Task.FromResult<User>(null));
            A.CallTo(() => _userRepository.AddUser(A<User>._, A<string>._)).Returns(Task.FromResult<IdentityResult>(IdentityResult.Success));

            //Act
            var response = _sut.RegisterUser(user).Result;

            //Assert
            response.Should().NotBeNull();
            response.Should().BeOfType<CreatedResult>();
            response.As<CreatedResult>().StatusCode.Should().Be((int) HttpStatusCode.Created);
        }

        [Fact]
        public void UserController_AddUser_Should_Create_An_User() {
            //Arrange
            var userRequest = A.Fake<UserRequestDTO>();
            var mappedUser = _mapper.Map<UserRequestDTO, User>(userRequest);

            var mappedResponse = A.Fake<IdentityUser>();

            A.CallTo(() => _userRepository.FindUserByEmail(A<string>._)).Returns(Task.FromResult<User>(null));
            A.CallTo(() => _userRepository.AddUser(A<User>._, A<string>._)).Returns(Task.FromResult<IdentityResult>(IdentityResult.Success));

            //Act
            var response = _sut.RegisterUser(userRequest).Result;

            A.CallTo(() => _userRepository.FindUserByEmail(A<string>._)).Returns(Task.FromResult<User>(mappedUser));
            var foundUser = _userRepository.FindUserByEmail(userRequest.Email);

            //Assert
            response.Should().NotBeNull();
            response.Should().BeOfType<CreatedResult>();
            response.As<CreatedResult>().StatusCode.Should().Be(201);
            response.As<CreatedResult>().Value.As<UserResponseDTO>().Should().NotBeNull();
            response.As<CreatedResult>().Value.As<UserResponseDTO>().Id.Should().NotBe(null);
            response.As<CreatedResult>().Value.As<UserResponseDTO>().Name.Should().Be(userRequest.Name);
            response.As<CreatedResult>().Value.As<UserResponseDTO>().Email.Should().Be(userRequest.Email);
            foundUser.Should().NotBe(null);
        }

        [Fact]
        public void UserController_Return_BadRequest_On_Wrong_Information() {
            // Arrange
            var userRequest = A.Fake<UserRequestDTO>();
            userRequest.Email = "onenotvalidemail.com";
            userRequest.Password = "abC12@!23456";
            userRequest.PasswordConfirmation = "Abc12@!23456";
            userRequest.Name = "Jane Doe";

            var mappedUser = _mapper.Map<UserRequestDTO, User>(userRequest);

            var mappedResponse = A.Fake<IdentityUser>();

            A.CallTo(() => _userRepository.FindUserByEmail(A<string>._)).Returns(Task.FromResult<User>(null));

            // Act
            var response = _sut.RegisterUser(userRequest).Result;

            response.Should().NotBeNull();
            response.As<BadRequestObjectResult>().StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            response.As<BadRequestObjectResult>().Value.Should().Be(ResponseErrorsEnum.MismatchPassword);
        }
    }
}
