namespace MahalliyMarket.DTOs.UserDTOs;

public class UserResponseDTO
{
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string? middle_name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string phone_number { get; set; }
    public DateTime? date_birth { get; set; }
    public string? province { get; set; }
    public string? city_district { get; set; }
    public string? mahalla { get; set; }
    public string? street { get; set; }
    public string? postal_code { get; set; }
    public decimal latitude { get; set; }
    public decimal longitude { get; set; }
}
