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
      public User User { get; set; }

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

      [ForeignKey("CategoryId")]
      public Category Category { get; set; }

      // public ICollection<ProductImage> Images { get; set; }

      public ICollection<OrderItem> OrderItems { get; set; }

      public ICollection<Feedback> Feedbacks { get; set; }
}
