using System.ComponentModel.DataAnnotations;

namespace Registration_Page_Task.Models
{
    public class Registrations
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Full name is required.")]
        public string FullName { get; set; } = string.Empty;
            
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Invalid phone number. Must be 10 digits starting with 6-9.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$", ErrorMessage = "Password must contain at least one uppercase letter, one number, and one special character.")]
        public string Password { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
