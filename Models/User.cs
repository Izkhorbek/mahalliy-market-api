using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MahalliyMarket.Models;

[Index(nameof(email), Name = "IX_Users_Email", IsUnique = true)]
public class User
{
      [Key]
      public int id { get; set; }

      [Required(ErrorMessage = "First name is required")]
      [StringLength(50, ErrorMessage = "First name must be at most 50 characters long")]
      public required string first_name { get; set; }


      [Required(ErrorMessage = "Last name is required")]
      [StringLength(50, ErrorMessage = "Last name must be at most 50 characters long")]
      public required string last_name { get; set; }

      [StringLength(50, ErrorMessage = "Middle name must be at most 50 characters long")]
      public string? middle_name { get; set; }

      [Required(ErrorMessage = "Email is required")]
      [EmailAddress(ErrorMessage = "Invalid email address")]
      [StringLength(100, ErrorMessage = "Email must be at most 100 characters long")]
      public required string email { get; set; }

      [Required]
      public required byte[] password_hash { get; set; }

      [Required]
      public required byte[] password_salt { get; set; }

      [Required(ErrorMessage = "Role is required")]
      [StringLength(50, ErrorMessage = "Role must be at most 50 characters long")]
      public required string role { get; set; }

      [Required(ErrorMessage = "Phone number is required")]
      [StringLength(20, ErrorMessage = "Phone number must be at most 20 characters long")]
      public required string phone { get; set; }

      public DateTime? date_birth { get; set; }

      public string? province { get; set; }

      public string? city_district { get; set; }

      public string? mahalla { get; set; }

      public string? street { get; set; }

      [Column(TypeName = "decimal(12,2)")]
      public decimal postal_code { get; set; }

      [Required]
      [Column(TypeName = "decimal(18,2)")]
      public decimal latitude { get; set; }

      [Required]
      [Column(TypeName = "decimal(18,2)")]
      public decimal longitude { get; set; }

      public DateTime created_at { get; set; }
      
      /// <summary>
      /// Collection of delivery methods offered by this seller
      /// </summary>
      public virtual ICollection<DeliveryMethod> delivery_methods { get; set; } = new List<DeliveryMethod>();

      /// <summary>
      /// Collection of orders placed by this customer
      /// </summary>
      public virtual ICollection<Order> orders { get; set; } = new List<Order>();

      /// <summary>
      /// Collection of delivery addresses for this customer
      /// </summary>
      public virtual ICollection<DeliveryAddress> delivery_addresses { get; set; } = new List<DeliveryAddress>();
}
