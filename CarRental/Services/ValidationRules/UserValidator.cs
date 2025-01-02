using CarRental.Models;
using FluentValidation;

namespace CarRental.Services.ValidationRules
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty.")
            .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
            .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname cannot be empty.")
                .MinimumLength(2).WithMessage("Surname must be at least 2 characters.")
                .MaximumLength(50).WithMessage("Surname cannot exceed 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number cannot be empty.")
                .Matches(@"^\d{10,15}$").WithMessage("Phone number must be between 10 and 15 digits.");
        }
    }
}
