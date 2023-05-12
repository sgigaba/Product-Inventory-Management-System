namespace Product_Inventory_Management_System.WebApiControllers
{
    using DevExtreme.AspNet.Data;
    using DevExtreme.AspNet.Mvc;

    using FluentValidation;
    using FluentValidation.Results;

    using Microsoft.AspNetCore.Mvc;

    using Product_Inventory_Management_System.Services;

    public class ProductWebApi : Controller
    {
        private readonly ProductService productService;
        private readonly IValidator validator;

        public ProductWebApi(ProductService productService, IValidator validator)
        {
            this.productService = productService;
            this.validator = validator;
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

            ValidationResult result = this.validator.Validate(model);

            return Ok(model);
        }

        [HttpDelete]

        public IActionResult Delete(int key) 
        {
            this.productService.Delete(key);

            return Ok();
        }
    }
}
