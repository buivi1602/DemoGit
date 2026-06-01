using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Models;

namespace FirstWebMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<DeviceCategory> DeviceCategories { get; set; }

        public DbSet<Device> Devices { get; set; }

        // ===== Nhập kho =====
        public DbSet<ImportReceipt> ImportReceipts { get; set; }

        public DbSet<ImportDetail> ImportDetails { get; set; }

        // ===== Xuất kho =====
        public DbSet<ExportReceipt> ExportReceipts { get; set; }

        public DbSet<ExportDetail> ExportDetails { get; set; }
    }
}