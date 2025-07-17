using System.ComponentModel.DataAnnotations;

namespace MahalliyMarket.DTOs.UserDTOs;

public class UserLoginDTO
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    [StringLength(100, ErrorMessage = "Email must be between 8 and 100 characters long", MinimumLength = 8)]
    public string email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    // Here password must be encrypted by Bcrypt
    public string password { get; set; }

}
