using System.ComponentModel.DataAnnotations;
namespace FirstWebMVC.Models;
public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "Tên không được để trống")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}