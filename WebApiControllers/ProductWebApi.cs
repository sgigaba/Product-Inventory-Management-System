namespace Product_Inventory_Management_System.WebApiControllers
{
    using DevExtreme.AspNet.Data;
    using DevExtreme.AspNet.Mvc;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    using Product_Inventory_Management_System.Models;

    public class ProductWebApi : Controller
    {
        private readonly ApplicationDbContext context;

        public ProductWebApi(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var products = context.Products.ToList();

            return DataSourceLoader.Load(products, loadOptions);
        }

        public IActionResult Create(string values)
        {
            var model = new Product();
                
            JsonConvert.PopulateObject(values, model);

            context.Products.Add(model);
            context.SaveChanges();

            return Ok(model);
        }
    }
}
