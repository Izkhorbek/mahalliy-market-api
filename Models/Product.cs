using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MahalliyMarket.Models;

public class Product
{
      [Key]
      public int id { get; set; }

      public int user_id { get; set; }

      [ForeignKey("user_id")]
      public User? user { get; set; } 

      [Required(ErrorMessage = "Product Name is required.")]
      [StringLength(100, MinimumLength = 10, ErrorMessage = "Product Name must be between 3 and 100 characters.")]
      public required string name { get; set; }

      [Required(ErrorMessage = "Description is required.")]
      [MinLength(300, ErrorMessage = "Description must be at least 300 characters.")]
      public required string description { get; set; }

      [Range(1, 10000000.00, ErrorMessage = "Price must be between $0.01 and $10,000.00.")]
      [Column(TypeName = "decimal(18,2)")]
      [Comment("Haqiqiy qiymayni olish uchun 1000ga ko'paytirib oling.")]
      public decimal price { get; set; }

      [Range(0, 1000, ErrorMessage = "Quantity must be between 0 and 1000.")]
      public int quantity { get; set; }

      [StringLength(200, ErrorMessage = "Image URL must be at most 200 characters long.")]
      public string? tags { get; set; }

      [Range(0, 100, ErrorMessage = "Discount Percentage must be between 0% and 100%.")]
      public int discount_percentage { get; set; }

      // Foreign key to Category
      [Required(ErrorMessage = "Category ID is required.")]
      public int category_id { get; set; }

      [ForeignKey("category_id")]
      public Category category { get; set; }

      /// <summary>
      /// ID of the primary/featured image for this product
      /// </summary>
      public int? product_image_id { get; set; }

      /// <summary>
      /// Navigation property to the primary/featured image
      /// </summary>
      [ForeignKey("product_image_id")]
      public virtual ProductImage? primary_image { get; set; }

      /// <summary>
      /// Collection of all images for this product
      /// </summary>
      public virtual ICollection<ProductImage> images { get; set; } = new List<ProductImage>();

      /// <summary>
      /// Collection of all videos for this product
      /// </summary>
      public virtual ICollection<ProductVideo> videos { get; set; } = new List<ProductVideo>();

      /// <summary>
      /// Collection of all feedback for this product
      /// </summary>
      public virtual ICollection<ProductFeedback> feedbacks { get; set; } = new List<ProductFeedback>();

      /// <summary>
      /// Collection of all sales records for this product
      /// </summary>
      public virtual ICollection<ProductSales> sales { get; set; } = new List<ProductSales>();

      /// <summary>
      /// Collection of all delivery options for this product
      /// </summary>
      public virtual ICollection<DeliveryMethod> delivery_options { get; set; } = new List<DeliveryMethod>();

      /// <summary>
      /// Collection of all order options for this product
      /// </summary>
      public virtual ICollection<OrderItem> order_items { get; set; } = new List<OrderItem>();
}
