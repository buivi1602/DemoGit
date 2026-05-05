using System.ComponentModel.DataAnnotations;

namespace FirstWebMVC.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, 100000)]
        public double Price { get; set; }
    }
}