using Homeo.Application.Interfaces;
using Homeo.Application.Repositories;

namespace Homeo.Api.IoC {
    public static class AddRepositories {
        /// <summary>
        /// Register the repositories inside the the <see cref="WebApplicationBuilder"/>
        /// </summary>
        /// <param name="builder">The <see cref="WebApplicationBuilder"/> that will have the repositories registered</param>
        public static void RegisterRepositories(this WebApplicationBuilder builder) {
            // User repository
            builder.Services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
