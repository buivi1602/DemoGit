using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class ExportReceipt
    {
        [Key]
        public int ExportId { get; set; }

        [Required]
        public string ExportCode { get; set; } = string.Empty;

        public DateTime ExportDate { get; set; } = DateTime.Now;

        public string? CustomerName { get; set; }

        public ICollection<ExportDetail>? ExportDetails { get; set; }
    }
}
