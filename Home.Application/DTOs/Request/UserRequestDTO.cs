using System.ComponentModel.DataAnnotations;

namespace Homeo.DTOs.Request {
    public class UserRequestDTO {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "User name must be between 3 and 50 characters long")]
        public string Name { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 10)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Must be a valid email")]
        public string Email { get; set; }

        [Required]
        [StringLength(36, MinimumLength = 8, ErrorMessage = "User password must be between 8 and 36 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Password must match")]
        public string PasswordConfirmation { get; set; }

        [Required(ErrorMessage = "Type of user must be defined")]
        [Range(0, 2, ErrorMessage = "The account type is invalid")]
        public int AccountType { get; set; }

        public UserRequestDTO() { }

        public UserRequestDTO(string name, string email, string password, int accountType) {
            Name = name;
            Email = email;
            Password = password;
            AccountType = accountType;
        }
    }
}
