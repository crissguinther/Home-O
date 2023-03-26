using Homeo.Application.Interfaces;
using Homeo.Domain;
using Microsoft.AspNetCore.Identity;
using System.Transactions;

namespace Homeo.Application.Repositories {
    public class UserRepository : IUserRepository {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> AddUser(User user, string password) {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled)) {
                var createdUser = await _userManager.CreateAsync(user, password);

                if (createdUser.Succeeded) {
                    scope.Complete();
                }
                else scope.Dispose();

                return createdUser;
            }
        }

        /// <summary>
        /// Finds a <see cref="User"/> by its email and returns if it is found
        /// </summary>
        /// <param name="email">A <see cref="string"/> that represents the user email.</param>
        /// <returns>The found <see cref="User"/> or <see cref="null"/> if it was not found</returns>
        public async Task<User> FindUserByEmail(string email) {
            var found = await _userManager.FindByEmailAsync(email);

            return found;
        }
    }
}
