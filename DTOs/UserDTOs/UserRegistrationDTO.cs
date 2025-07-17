using MahalliyMarket.Models;
using System.ComponentModel.DataAnnotations;

namespace MahalliyMarket.DTOs.UserDTOs
{
    public class UserRegistrationDTO
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public required string first_name { get; set; }


        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public required string last_name { get; set; }

        [StringLength(50, ErrorMessage = "Middle name must be at most 50 characters long")]
        public string? middle_name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100, ErrorMessage = "Email must be at most 100 characters long")]
        public required string email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "Password must be between 8 and 100 characters.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        //   [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&]).{8,}$",
        //     ErrorMessage = "Password must be at least 8 characters long and include uppercase, lowercase, number, and special character.")]

        // Here password must be encoded using BCrypt
        public required string password { get; set; }

        [Required(ErrorMessage = "Role is required")]
        [EnumDataType(typeof(ERole), ErrorMessage = "Role must be either Seller or Customer.")]
        public ERole user_role { get; set; } = ERole.Customer;

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(20, ErrorMessage = "Phone number must be at most 20 characters long")]
        [RegularExpression(@"^\+998\d{9}$", ErrorMessage = "Phone number must be in the format +998XXXXXXXXX")]
        public required string phone_number { get; set; }

        public DateTime? date_birth { get; set; }

        public string? province { get; set; }

        public string? city_district { get; set; }

        public string? mahalla { get; set; }

        public string? street { get; set; }

        public string postal_code { get; set; }

        [Required(ErrorMessage = "Latitude is required")]
        public decimal latitude { get; set; }

        [Required(ErrorMessage = "Longitude is required")]
        public decimal longitude { get; set; }
    }
}
