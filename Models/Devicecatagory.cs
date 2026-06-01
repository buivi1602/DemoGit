using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class DeviceCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Tên loại không được để trống")]
        [StringLength(100)]
        public string CategoryName { get; set; } = string.Empty;

        public string? Description { get; set; }
    }
}