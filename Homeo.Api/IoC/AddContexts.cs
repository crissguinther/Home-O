using Homeo.Data.Data;
using Homeo.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace Homeo.IoC
{
    public static class AddContexts {
        /// <summary>
        /// Adds the application database contexts into the web application.
        /// </summary>
        /// <param name="builder">The <see cref="WebApplicationBuilder"/> that will be used.</param>
        /// <exception cref="Exception">An exception that will be thrown if the connection
        /// string is not found.
        /// </exception>
        public static void AddApplicationContexts(this WebApplicationBuilder builder) {
            IConfiguration configuration = builder.Configuration;
            string connectionString = configuration.GetConnectionString("default");

            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("Connection string was not set");

            builder.Services.AddDbContext<HomeoDataContext>(options =>
                options.UseSqlServer(connectionString)
            );

            builder.Services.AddDbContext<IdentityDataContext>(options =>
                options.UseSqlServer(connectionString)
            );
        }
    }
}
