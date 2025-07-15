using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahalliyMarket.Models;

public class DeliveryAddress
{
    /// <summary>
    /// Unique identifier for the delivery address
    /// </summary>
    [Key]
    public int address_id { get; set; }

    /// <summary>
    /// ID of the customer who owns this address
    /// </summary>
    [Required(ErrorMessage = "Customer ID is required for delivery address")]
    public int customer_id { get; set; }

    /// <summary>
    /// Navigation property to the customer
    /// </summary>
    [ForeignKey("customer_id")]
    public User? customer { get; set; }

    /// <summary>
    /// Name for this address (e.g., "Home", "Work", "Summer House")
    /// </summary>
    [Required(ErrorMessage = "Address name is required")]
    [StringLength(100, ErrorMessage = "Address name cannot exceed 100 characters")]
    public string address_name { get; set; } = string.Empty;

    /// <summary>
    /// Recipient's full name
    /// </summary>
    [Required(ErrorMessage = "Recipient name is required")]
    [StringLength(100, ErrorMessage = "Recipient name cannot exceed 100 characters")]
    public string recipient_name { get; set; } = string.Empty;

    /// <summary>
    /// Recipient's phone number
    /// </summary>
    [Required(ErrorMessage = "Phone number is required")]
    [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
    public string phone_number { get; set; } = string.Empty;

    /// <summary>
    /// Province/Region
    /// </summary>
    [Required(ErrorMessage = "Province is required")]
    [StringLength(50, ErrorMessage = "Province cannot exceed 50 characters")]
    public string province { get; set; } = string.Empty;

    /// <summary>
    /// City or District
    /// </summary>
    [Required(ErrorMessage = "City/District is required")]
    [StringLength(50, ErrorMessage = "City/District cannot exceed 50 characters")]
    public string city_district { get; set; } = string.Empty;

    /// <summary>
    /// Mahalla (neighborhood)
    /// </summary>
    [StringLength(50, ErrorMessage = "Mahalla cannot exceed 50 characters")]
    public string? mahalla { get; set; }

}
