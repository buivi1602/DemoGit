using System.ComponentModel.DataAnnotations;
namespace FirstWebMVC.Models;
public class OrderDetail
{
    [Key]
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }
    public Order? Order { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    [Range(1, 100)]
    public int Quantity { get; set; }
}