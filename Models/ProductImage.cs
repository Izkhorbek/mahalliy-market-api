using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahalliyMarket.Models;

public class ProductImage
{
    /// <summary>
    /// Unique identifier for the product image
    /// </summary>
    [Key]
    public int image_id { get; set; }

    ///// <summary>
    ///// ID of the product this image belongs to  
    ///// one to many relationship with product
    ///// </summary>
    //[Required(ErrorMessage = "Product ID is required for product image")]
    //public int product_id { get; set; }

    ///// <summary>
    ///// Navigation property to the product
    ///// </summary>
    //[ForeignKey("product_id")]
    //public Product? product { get; set; }

    /// <summary>
    /// URL to the product image
    /// </summary>
    [Required(ErrorMessage = "Image URL is required")]
    [StringLength(500, ErrorMessage = "Image URL cannot exceed 500 characters")]
    public string image_url { get; set; } = string.Empty;

    /// <summary>
    /// Alt text for the image (for accessibility and SEO)
    /// </summary>
    [StringLength(200, ErrorMessage = "Alt text cannot exceed 200 characters")]
    public string? alt_text { get; set; }

    /// <summary>
    /// Order in which images should be displayed (1 = primary image)
    /// </summary>
    public int display_order { get; set; } = 1;

    /// <summary>
    /// Indicates if this is the primary/featured image for the product
    /// </summary>
    public bool is_primary { get; set; } = false;

    /// <summary>
    /// Indicates if the image is active and visible
    /// </summary>
    public bool is_active { get; set; } = true;

    /// <summary>
    /// File size of the image in bytes
    /// </summary>
    public long? file_size { get; set; }

    /// <summary>
    /// MIME type of the image (e.g., "image/jpeg", "image/png")
    /// </summary>
    [StringLength(50, ErrorMessage = "MIME type cannot exceed 50 characters")]
    public string? mime_type { get; set; }

    /// <summary>
    /// Width of the image in pixels
    /// </summary>
    public int? width { get; set; }

    /// <summary>
    /// Height of the image in pixels
    /// </summary>
    public int? height { get; set; }

    /// <summary>
    /// Caption or description for the image
    /// </summary>
    [StringLength(300, ErrorMessage = "Caption cannot exceed 300 characters")]
    public string? caption { get; set; }

    /// <summary>
    /// Timestamp when the image was uploaded/created
    /// </summary>
    public DateTime created_at { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Timestamp when the image was last updated
    /// </summary>
    public DateTime updated_at { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// ID of the user who uploaded the image
    /// </summary>
    public int? uploaded_by { get; set; }

    /// <summary>
    /// Navigation property to the user who uploaded the image
    /// </summary>
    [ForeignKey("uploaded_by")]
    public User? uploader { get; set; }
}
