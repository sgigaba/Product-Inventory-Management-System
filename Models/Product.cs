using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_Inventory_Management_System.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public int? Category { get; set; }

        public string? Status { get; set; }

        [NotMapped]
        public List<ProductCategories> CategoryList { get; set; }
    }
}
