using System.ComponentModel.DataAnnotations;
namespace FirstWebMVC.Models;
public class Order
{
    [Key]
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    // FK
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}