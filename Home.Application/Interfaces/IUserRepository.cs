using Homeo.Domain;
using Microsoft.AspNetCore.Identity;

namespace Homeo.Application.Interfaces {
    public interface IUserRepository {
        Task<IdentityResult> AddUser(User user, string password);
        Task<User> FindUserByEmail(string email);
    }
}
