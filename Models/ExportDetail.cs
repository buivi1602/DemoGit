using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class ExportDetail
    {
        [Key]
        public int ExportDetailId { get; set; }

        // Khóa ngoại Phiếu xuất
        public int ExportId { get; set; }
        public ExportReceipt? ExportReceipt { get; set; }

        // Khóa ngoại Thiết bị
        public int DeviceId { get; set; }
        public Device? Device { get; set; }

        public decimal ExportPrice { get; set; }

        public int Quantity { get; set; }

        public decimal TotalAmount
        {
            get { return ExportPrice * Quantity; }
        }
    }
}
