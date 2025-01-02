using CarRental.Models;
using FluentValidation;

namespace CarRental.Services.ValidationRules
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator() 
        {
            
            RuleFor(r => r.RentalStartDate)
                .NotEmpty().WithMessage("start date not empty!")
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("startdate cannot be in the past");
            RuleFor(r => r.RentalEndDate)
                .NotEmpty().WithMessage("start date not empty!")
                .GreaterThan(x => x.RentalStartDate).WithMessage("endDate must be after startDate");


        }
    }
}
