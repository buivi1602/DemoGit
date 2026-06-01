using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class ImportReceipt
    {
        [Key]
        public int ImportId { get; set; }

        public DateTime ImportDate { get; set; }

        public int SupplierId { get; set; }

        public Supplier? Supplier { get; set; }

        public ICollection<ImportDetail>? ImportDetails { get; set; }
    }
}