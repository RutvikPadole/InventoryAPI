using FluentValidation;
using InventoryManagementAPI.DTOs;

namespace InventoryManagementAPI.Validators
{
    public class ProductValidator :AbstractValidator<ProductDto>
    {
        public ProductValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }

}
