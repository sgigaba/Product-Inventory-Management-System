using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Product_Inventory_Management_System.Models;

namespace Product_Inventory_Management_System.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext context;
        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Product Add(string values)
        {
            var model = new Product();

            JsonConvert.PopulateObject(values, model);
            context.Products.Add(model);
            context.SaveChanges();

            return model;
        }

        public List<Product> Get()
        {
            var products = context.Products.ToList();

            return products;
        }
    }
}
