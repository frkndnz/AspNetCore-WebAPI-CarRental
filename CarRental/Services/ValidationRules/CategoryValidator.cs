using CarRental.Models;
using FluentValidation;

namespace CarRental.Services.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Category is not empty!")
                .Must(value => value != "string").WithMessage("property is cannot be 'string'");
        }
    }
}
