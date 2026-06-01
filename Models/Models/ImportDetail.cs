using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class ImportDetail
    {
        [Key]
        public int ImportDetailId { get; set; }

        // Khóa ngoại Phiếu nhập
        public int ImportId { get; set; }
        public ImportReceipt? ImportReceipt { get; set; }

        // Khóa ngoại Thiết bị
        public int DeviceId { get; set; }
        public Device? Device { get; set; }

        [Required]
        public decimal ImportPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        // Thành tiền tự động tính
        public decimal TotalAmount
        {
            get { return ImportPrice * Quantity; }
        }
    }
}