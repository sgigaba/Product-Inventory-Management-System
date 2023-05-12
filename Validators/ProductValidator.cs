namespace Product_Inventory_Management_System.Validators
{
    using FluentValidation;

    using Product_Inventory_Management_System.Models;

    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator() 
        {
            this.RuleSet("Create", () =>
            {
                this.RuleFor(_ => _.Name)
                .NotEmpty();

                this.RuleFor(_ => _.Description)
                    .NotEmpty();

                this.RuleFor(_ => _.Price)
                    .GreaterThanOrEqualTo(0);

                this.RuleFor(_ => _.Quantity)
                    .GreaterThanOrEqualTo(0);
            });
        }
    }
}
