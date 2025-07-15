using System.ComponentModel.DataAnnotations;

namespace MahalliyMarket.Models;

// Represents the status master
public class Status
{
    [Key]
    public int status_id { get; set; }

    [Required]
    [StringLength(50)]
    public string status_name { get; set; }
}