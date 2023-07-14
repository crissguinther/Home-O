using Homeo.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Homeo.Domain.Entities
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Document { get; set; }

        [Required]
        public bool IsLegalEntity { get; set; }

        [Required]
        public AccountTypeEnum AccountType { get; set; }

        public List<Property> Properties { get; set; }
    }
}