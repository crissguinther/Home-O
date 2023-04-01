using Homeo.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Homeo.Identity.Data {
    /// <summary>
    /// Data context used for the Microsoft Identity database
    /// </summary>
    public class IdentityDataContext : IdentityDbContext<User> {
        public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options) { }
    }
}
