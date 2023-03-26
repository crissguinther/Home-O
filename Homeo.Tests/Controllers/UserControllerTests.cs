using FakeItEasy;
using FluentAssertions;
using Homeo.Api.Controllers;
using Homeo.Application.Interfaces;
using Homeo.Application.Repositories;
using Homeo.Data.Interfaces;
using Homeo.Domain;
using Homeo.DTOs.Request;
using Homeo.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Xunit;

namespace Homeo.Tests.Controllers {
    public class UserControllerTests {
        private readonly IdentityDataContext _identityContext;
        private readonly UserController _sut;

        public UserControllerTests() {
            var fakeUserManager = A.Fake<UserManager<User>>();
            var fakeSignInManager = A.Fake<SignInManager<User>>();
            var fakeUok = A.Fake<IUnitOfWork>();
            var repository = new UserRepository(fakeUserManager, fakeSignInManager, fakeUok);

            _sut = new UserController(repository);
        }   

        [Fact]
        public void UserController_Should_Not_Return_Empty() {
            // Arrange
            var user = new AddUserRequestDTO {
                Name = "JohnDoe",
                Email = "johndoe@email.com",
                Password = "AVeryStrongPassword123456@",
                AccountType = 2
            };

            // Act
            var response = _sut.RegisterUser(user);

            // Assert
            response.Should().NotBeNull();
        }
    }
}
