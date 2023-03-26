using Homeo.Data.Interfaces;
using Homeo.Data.UnitOfWork;

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

            // Auto Mapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Unit of Work
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
