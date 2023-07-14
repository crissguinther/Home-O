using Homeo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Homeo.Data.Data
{
    public class HomeoDataContext : DbContext
    {
        public HomeoDataContext(DbContextOptions<HomeoDataContext> options) : base(options) { }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
    }
}