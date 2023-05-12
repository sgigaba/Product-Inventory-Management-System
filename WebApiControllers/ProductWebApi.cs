namespace Product_Inventory_Management_System.WebApiControllers
{
    using DevExtreme.AspNet.Data;
    using DevExtreme.AspNet.Mvc;

    using Microsoft.AspNetCore.Mvc;

    using Product_Inventory_Management_System.Models;

    public class ProductWebApi : Controller
    {
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var model = new Product()
            {
                Id = 1,
                Name = "Soap",
                Description = "Soapy",
                Price = 1.45,
                Quantity = 25
            };

            List<Product> products = new List<Product>();
            products.Add(model);

            return DataSourceLoader.Load(products, loadOptions);
        }
    }
}
