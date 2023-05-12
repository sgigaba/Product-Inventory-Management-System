namespace Product_Inventory_Management_System
{
    using Microsoft.EntityFrameworkCore;

    using Product_Inventory_Management_System.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
