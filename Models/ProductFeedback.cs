using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahalliyMarket.Models;

public class ProductFeedback
{
    /// <summary>
    /// Unique identifier for the product feedback
    /// </summary>
    [Key]
    public int feedback_id { get; set; }

    /// <summary>
    /// ID of the user who left the feedback
    /// </summary>
    [Required(ErrorMessage = "User ID is required for feedback")]
    public int customer_id { get; set; }

    /// <summary>
    /// Navigation property to the user who left the feedback
    /// </summary>
    [ForeignKey("customer_id")]
    public User? customer { get; set; }

    /// <summary>
    /// ID of the product this feedback is for
    /// </summary>
    [Required(ErrorMessage = "Product ID is required for feedback")]
    public int product_id { get; set; }

    /// <summary>
    /// Navigation property to the product
    /// </summary>
    [ForeignKey("product_id")]
    public Product? product { get; set; }

    /// <summary>
    /// Rating given by the user (1-5 stars)
    /// </summary>
    [Required(ErrorMessage = "Rating is required")]
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
    public int rating { get; set; }

    /// <summary>
    /// Comment text from the user
    /// </summary>
    [Required(ErrorMessage = "Comment text is required")]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "Comment must be between 10 and 1000 characters")]
    public string comment_text { get; set; } = string.Empty;

    //     /// <summary>
    //     /// Title/headline of the feedback
    //     /// </summary>
    //     [StringLength(200, ErrorMessage = "Feedback title cannot exceed 200 characters")]
    //     public string? feedback_title { get; set; }

    /// <summary>
    /// Indicates if this feedback is verified (purchased the product)
    /// </summary>
    public bool is_verified_purchase { get; set; } = false;

    /// <summary>
    /// Indicates if this feedback is helpful/useful
    /// </summary>
    public bool is_helpful { get; set; } = false;

    /// <summary>
    /// Number of users who found this feedback helpful
    /// </summary>
    public int helpful_count { get; set; } = 0;

    /// <summary>
    /// Number of users who found this feedback not helpful
    /// </summary>
    public int not_helpful_count { get; set; } = 0;

    /// <summary>
    /// Indicates if the feedback is active and visible
    /// </summary>
    public bool is_active { get; set; } = true;

    /// <summary>
    /// Indicates if the feedback has been moderated/approved
    /// </summary>
    public bool is_approved { get; set; } = false;

    /// <summary>
    /// Admin/moderation notes for this feedback
    /// </summary>
    [StringLength(500, ErrorMessage = "Moderation notes cannot exceed 500 characters")]
    public string? moderation_notes { get; set; }

    ///// <summary>
    ///// ID of the order this feedback is related to (if verified purchase)
    ///// </summary>
    //public int? order_id { get; set; }

    ///// <summary>
    ///// Navigation property to the related order
    ///// </summary>
    //[ForeignKey("order_id")]
    //public Order? order { get; set; }

    /// <summary>
    /// Timestamp when the feedback was created
    /// </summary>
    public DateTime created_at { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Timestamp when the feedback was last updated
    /// </summary>
    public DateTime updated_at { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Timestamp when the feedback was moderated/approved
    /// </summary>
    public DateTime? moderated_at { get; set; }

    /// <summary>
    /// ID of the admin who moderated this feedback
    /// </summary>
    public int? moderated_by { get; set; }

    /// <summary>
    /// Navigation property to the admin who moderated the feedback
    /// </summary>
    [ForeignKey("moderated_by")]
    public User? moderator { get; set; }
}

//Eslatma
/*
    Moderator roli
    Moderator — foydalanuvchilarning yozgan feedbacklarini:

    Ko‘rib chiqadi (review) — spam, haqorat, noto‘g‘ri baholarni tekshiradi

    Tasdiqlaydi yoki rad etadi (approved/rejected)

    Tahrir qiladi (agar kerak bo‘lsa)

    Bloklaydi yoki yashiradi (visible = false)
 */