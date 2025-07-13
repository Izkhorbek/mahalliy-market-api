using System.ComponentModel.DataAnnotations;
using namespace MahalliyMarket.Models.Enums;

// Represents the status master
public class Status
{
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
}