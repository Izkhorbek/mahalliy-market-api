using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahalliyMarket.Models;

public class ProductHot
{
    /// <summary>
    /// Unique identifier for the hot product entry
    /// </summary>
    [Key]
    public int id { get; set; }

    /// <summary>
    /// Foreign key referencing the associated product
    /// </summary>
    [Required]
    public int product_id { get; set; }

    /// <summary>
    /// Navigation property to the associated product
    /// </summary>
    [ForeignKey("product_id")]
    public Product product { get; set; }

    /// <summary>
    /// Priority of the hot product (higher means more prominent)
    /// </summary>
    public int priority { get; set; } = 0;

    /// <summary>
    /// Indicates if the hot product entry is currently active
    /// </summary>
    public bool is_active { get; set; } = true;

    /// <summary>
    /// Optional expiration date/time for the hot status
    /// </summary>
    public DateTime? expires_at { get; set; }

    /// <summary>
    /// Optional: Reason or tag for being hot (e.g., "trending", "editor's pick")
    /// </summary>
    [StringLength(200)]
    public string? tag { get; set; }

    /// <summary>
    /// The date/time when the product was marked as hot
    /// </summary>
    public DateTime created_at { get; set; } = DateTime.UtcNow;

}
