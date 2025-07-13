using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahalliyMarket.Models;

public class ProductVideo
{
    /// <summary>
    /// Unique identifier for the product video
    /// </summary>
    [Key]
    public int video_id { get; set; }
    
    /// <summary>
    /// URL to the product video (YouTube, Vimeo, or direct file URL)
    /// </summary>
    [Required(ErrorMessage = "Video URL is required")]
    [StringLength(500, ErrorMessage = "Video URL cannot exceed 500 characters")]
    public string video_url { get; set; } = string.Empty;
    
    /// <summary>
    /// Title/name of the video
    /// </summary>
    [Required(ErrorMessage = "Video title is required")]
    [StringLength(200, ErrorMessage = "Video title cannot exceed 200 characters")]
    public string video_title { get; set; } = string.Empty;
    
    /// <summary>
    /// Description of the video content
    /// </summary>
    [StringLength(500, ErrorMessage = "Video description cannot exceed 500 characters")]
    public string? video_description { get; set; }
    
    /// <summary>
    /// Thumbnail image URL for the video
    /// </summary>
    [StringLength(500, ErrorMessage = "Thumbnail URL cannot exceed 500 characters")]
    public string? thumbnail_url { get; set; }
    
    /// <summary>
    /// Order in which videos should be displayed (1 = primary video)
    /// </summary>
    public int display_order { get; set; } = 1;
    
    /// <summary>
    /// Indicates if this is the primary/featured video for the product
    /// </summary>
    public bool is_primary { get; set; } = false;
    
    /// <summary>
    /// Indicates if the video is active and visible
    /// </summary>
    public bool is_active { get; set; } = true;
    
    /// <summary>
    /// Duration of the video in seconds
    /// </summary>
    public int? duration_seconds { get; set; }
    
    /// <summary>
    /// File size of the video in bytes
    /// </summary>
    public long? file_size { get; set; }
    
    /// <summary>
    /// MIME type of the video (e.g., "video/mp4", "video/webm")
    /// </summary>
    [StringLength(50, ErrorMessage = "MIME type cannot exceed 50 characters")]
    public string? mime_type { get; set; }
    
    /// <summary>
    /// Video quality/resolution (e.g., "720p", "1080p", "4K")
    /// </summary>
    [StringLength(20, ErrorMessage = "Video quality cannot exceed 20 characters")]
    public string? video_quality { get; set; }
    
    /// <summary>
    /// Video format (e.g., "MP4", "WebM", "AVI")
    /// </summary>
    [StringLength(10, ErrorMessage = "Video format cannot exceed 10 characters")]
    public string? video_format { get; set; }
    
    /// <summary>
    /// Number of times the video has been viewed
    /// </summary>
    public int view_count { get; set; } = 0;
    
    /// <summary>
    /// Video platform type (YouTube, Vimeo, Direct, Local, etc.)
    /// </summary>
    public EVideoPlatform platform_type { get; set; } = EVideoPlatform.Direct;
    
    /// <summary>
    /// External video ID (for YouTube/Vimeo videos)
    /// </summary>
    [StringLength(50, ErrorMessage = "External video ID cannot exceed 50 characters")]
    public string? external_video_id { get; set; }
    
    /// <summary>
    /// Timestamp when the video was uploaded/created
    /// </summary>
    public DateTime created_at { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Timestamp when the video was last updated
    /// </summary>
    public DateTime updated_at { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// ID of the user who uploaded the video
    /// </summary>
    public int? uploaded_by { get; set; }
    
    /// <summary>
    /// Navigation property to the user who uploaded the video
    /// </summary>
    [ForeignKey("uploaded_by")]
    public virtual User? uploader { get; set; }

}
