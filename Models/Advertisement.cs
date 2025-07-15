using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahalliyMarket.Models;

public class Advertisement
{
    /// <summary>
    /// Unique identifier for the advertisement
    /// </summary>
    [Key]
    public int ads_id { get; set; }

    /// <summary>
    /// ID of the product being advertised
    /// </summary>
    [Required(ErrorMessage = "Product ID is required for advertisement")]
    public int product_id { get; set; }

    /// <summary>
    /// Navigation property to the advertised product
    /// </summary>
    [ForeignKey("product_id")]
    public Product? product { get; set; }

    /// <summary>
    /// Advertisement title/headline
    /// </summary>
    [Required(ErrorMessage = "Advertisement title is required")]
    [StringLength(100, ErrorMessage = "Advertisement title cannot exceed 100 characters")]
    public string ads_title { get; set; } = string.Empty;

    /// <summary>
    /// Advertisement text/description
    /// </summary>
    [Required(ErrorMessage = "Advertisement text is required")]
    [StringLength(500, ErrorMessage = "Advertisement text cannot exceed 500 characters")]
    public string ads_text { get; set; } = string.Empty;

    /// <summary>
    /// URL to the advertisement image
    /// </summary>
    [StringLength(255, ErrorMessage = "Image URL cannot exceed 255 characters")]
    public string? ads_image { get; set; }

    /// <summary>
    /// Indicates whether the advertisement is active and visible
    /// </summary>
    public bool is_active { get; set; } = true;

    /// <summary>
    /// Date when the advertisement starts being displayed
    /// </summary>
    [Required(ErrorMessage = "Start date is required")]
    public DateTime start_date { get; set; }

    /// <summary>
    /// Date when the advertisement stops being displayed
    /// </summary>
    [Required(ErrorMessage = "End date is required")]
    public DateTime end_date { get; set; }

    /// <summary>
    /// Priority level for advertisement display order (higher number = higher priority)
    /// </summary>
    public int priority { get; set; } = 1;

    /// <summary>
    /// Type of advertisement (e.g., "Banner", "Featured", "Promotion", "New Arrival")
    /// </summary>
    [StringLength(50, ErrorMessage = "Advertisement type cannot exceed 50 characters")]
    public string? ads_type { get; set; }

    /// <summary>
    /// Number of times the advertisement has been viewed
    /// </summary>
    public int view_count { get; set; } = 0;

    /// <summary>
    /// Number of times the advertisement has been clicked
    /// </summary>
    public int click_count { get; set; } = 0;

    /// <summary>
    /// Timestamp when the advertisement was created
    /// </summary>
    public DateTime created_at { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Timestamp when the advertisement was last updated
    /// </summary>
    public DateTime updated_at { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// ID of the user/business who created the advertisement
    /// </summary>
    public int? created_by { get; set; }

    /// <summary>
    /// Navigation property to the user who created the advertisement
    /// </summary>
    [ForeignKey("created_by")]
    public User? creator { get; set; }
}
