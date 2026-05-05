using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebMVC.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã sinh viên không được để trống")]
        public string StudentCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tên không được để trống")]
        public string FullName { get; set; } = string.Empty;

        // Foreign Key
        [Display(Name = "Khoa")]
        public int FacultyId { get; set; }

        // Navigation
        public Faculty? Faculty { get; set; }
    }
}