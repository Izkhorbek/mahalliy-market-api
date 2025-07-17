using System.ComponentModel.DataAnnotations;

namespace MahalliyMarket.DTOs.UserDTOs
{
    public class UserDTO
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name must be at most 50 characters long")]
        public required string first_name { get; set; }


        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name must be at most 50 characters long")]
        public string last_name { get; set; }

        [StringLength(50, ErrorMessage = "Middle name must be at most 50 characters long")]
        public string? middle_name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100, ErrorMessage = "Email must be at most 100 characters long")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string password { get; set; }

        [Required(ErrorMessage = "Role is required")]
        [StringLength(50, ErrorMessage = "Role must be at most 50 characters long")]
        public string user_role { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(20, ErrorMessage = "Phone number must be at most 20 characters long")]
        public string phone_number { get; set; }

        public DateTime? date_birth { get; set; }

        public string? province { get; set; }

        public string? city_district { get; set; }

        public string? mahalla { get; set; }

        public string? street { get; set; }

        public decimal postal_code { get; set; }

        [Required(ErrorMessage = "Latitude is required")]
        public decimal latitude { get; set; }

        [Required(ErrorMessage = "Longitude is required")]
        public decimal longitude { get; set; }
    }
}
