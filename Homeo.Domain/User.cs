using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Homeo.Domain {
    public class User : IdentityUser {
        [Required]
        public int AccountType { get; set; }

        [Required]
        public string Name { get; set; }
    }
}