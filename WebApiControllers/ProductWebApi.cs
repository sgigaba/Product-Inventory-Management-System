namespace Product_Inventory_Management_System.WebApiControllers
{
    using DevExtreme.AspNet.Data;
    using DevExtreme.AspNet.Mvc;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    using Product_Inventory_Management_System.Models;
    using Product_Inventory_Management_System.Services;

    public class ProductWebApi : Controller
    {
        private readonly ProductService productService;

        public ProductWebApi(ProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var products = productService.Get();
            return DataSourceLoader.Load(products, loadOptions);
        }

        [HttpPost]
        public IActionResult Create(string values)
        {
            var model = productService.Add(values);

            return Ok(model);
        }
    }
}
