using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class Device
    {
        [Key]
        public int DeviceId { get; set; }

        [Required(ErrorMessage = "Tên thiết bị không được để trống")]
        public string DeviceName { get; set; }

        public string? Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Giá phải >= 0")]
        public double Price { get; set; }

        // 🔗 Khóa ngoại
        public int CategoryId { get; set; }
        public DeviceCategory? Category { get; set; }
    }
}