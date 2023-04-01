using Homeo.Application.Profiles;
using Homeo.Data.Interfaces;
using Homeo.Data.UnitOfWork;
using Homeo.Domain;
using Homeo.Identity.Data;
using System.Reflection;

namespace Homeo.IoC {
    public static class BuildServices {
        /// <summary>
        /// An extension method used for IoC. Builds the services and adds it to the
        /// application builder.
        /// </summary>
        /// <param name="builder">The <see cref="WebApplicationBuilder"/> that will 
        /// be used.
        /// </param>
        public static void AddServices(this WebApplicationBuilder builder) {
            // Base
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Identity
            builder.Services.AddDefaultIdentity<User>(opt =>
                opt.User.RequireUniqueEmail = true
            ).AddEntityFrameworkStores<IdentityDataContext>();
            builder.Services.AddAuthentication();

            // Auto Mapper
            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(UserProfile)));

            // Unit of Work
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
