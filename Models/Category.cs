using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahalliyMarket.Models;

public class Category
{
    /// <summary>
    /// Unique identifier for the category
    /// </summary>
    [Key]
    public int category_id { get; set; }
    
    /// <summary>
    /// Name of the category (e.g., "Handmade Furniture", "Agro Technology", "Construction Materials")
    /// </summary>
    [Required(ErrorMessage = "Category name is required")]
    [StringLength(100)]
    public string category_name { get; set; } = string.Empty;
    
    /// <summary>
    /// Detailed description of the category and what types of local products it contains
    /// </summary>
    [StringLength(500)]
    public string? description { get; set; }
    
    /// <summary>
    /// Indicates whether the category is active and visible to customers
    /// </summary>
    public bool is_active { get; set; } = true;
    
    /// <summary>
    /// URL to the category's representative image for display in the marketplace
    /// </summary>
    [StringLength(255)]
    public string? image_url { get; set; }
    
    /// <summary>
    /// ID of the parent category for hierarchical structure (e.g., "Furniture" -> "Wooden Furniture" -> "Chairs")
    /// </summary>
    public int? parent_category_id { get; set; }
    
    /// <summary>
    /// Navigation property to the parent category for hierarchical organization
    /// </summary>
    [ForeignKey("parent_category_id")]
    public Category? parent_category { get; set; }
    
    /// <summary>
    /// Order in which categories should be displayed in the marketplace
    /// </summary>
    public int sort_order { get; set; } = 0;
    
    /// <summary>
    /// Timestamp when the category was created
    /// </summary>
    public DateTime created_at { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Timestamp when the category was last updated
    /// </summary>
    public DateTime updated_at { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Collection of sub-categories (child categories) for hierarchical organization
    /// </summary>
    public virtual ICollection<Category> sub_categories { get; set; } = new List<Category>();
    
    /// <summary>
    /// Collection of local products belonging to this category
    /// </summary>
    public virtual ICollection<Product> products { get; set; } = new List<Product>();
}
