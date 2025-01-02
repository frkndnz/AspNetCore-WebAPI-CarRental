using CarRental.Models;
using FluentValidation;
namespace CarRental.Services.ValidationRules
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Brand)
                .NotEmpty().WithMessage("Marka boş olamaz")
                .Length(2, 50).WithMessage("Marka 2-50 karakter arasında olmalıdır")
                .Must(value => value != "string").WithMessage("cannot be 'string'");
                
            RuleFor(c=>c.Model)
                .NotEmpty().WithMessage("Model boş olamaz!")
                .Length(2, 50).WithMessage("Model 2-50 karakter arasında olmalıdır")
                .Must(value => value != "string").WithMessage("cannot be 'string'");

            RuleFor(c => c.Price)
                .NotEmpty().WithMessage("Fiyat boş olamaz")
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır!");
            
        }
    }
}
