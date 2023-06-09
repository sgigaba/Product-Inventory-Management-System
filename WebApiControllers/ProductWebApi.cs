﻿namespace Product_Inventory_Management_System.WebApiControllers
{
    using DevExtreme.AspNet.Data;
    using DevExtreme.AspNet.Mvc;

    using FluentValidation;
    using FluentValidation.AspNetCore;
    using FluentValidation.Results;

    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Product_Inventory_Management_System.Models;
    using Product_Inventory_Management_System.Services;
    using Product_Inventory_Management_System.Validators;

    using System.ComponentModel.DataAnnotations;

    public class ProductWebApi : Controller
    {
        private readonly ProductService productService;
        private readonly IValidator<Product> validator;

        public ProductWebApi(ProductService productService, IValidator<Product> validator)
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
            var model = new Product();

            JsonConvert.PopulateObject(values, model);

            var result = this.validator.Validate(model, _ => _.IncludeRuleSets("Create"));

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return this.BadRequest(this.ModelState.ToFullErrorString());
            }

            model = productService.Add(values);


            return Ok(model);
        }

        [HttpDelete]

        public IActionResult Delete(int key) 
        {
            this.productService.Delete(key);

            return Ok();
        }

        [HttpGet]
        public IActionResult GetProductCategories(DataSourceLoadOptions loadOptions)
        {
            var babyAndToddler = new ProductCategories()
            {
                Id = 1,
                Category = "Baby & Toddler"
            };

            var beauty = new ProductCategories()
            {
                Id = 2,
                Category = "Beauty"
            };

            var books = new ProductCategories()
            {
                Id = 3,
                Category = "Books"
            };

            var computersAndElectronics = new ProductCategories()
            {
                Id = 3,
                Category = "Computers & Electronics"
            };

            List<ProductCategories> categories = new List<ProductCategories>();
            categories.Add(babyAndToddler);
            categories.Add(beauty);
            categories.Add(books);
            categories.Add(computersAndElectronics);

            return this.Json(DataSourceLoader.Load(categories, loadOptions));
        }
    }
}
