using DiarioDelGelato.Application.DTOs.Identity;
using DiarioDelGelato.Domain.Validations.Rules;
using FluentValidation;

namespace DiarioDelGelato.Application.Validators.Identity
{
    public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequestDTO>
    {
        public AuthenticationRequestValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required")
                .MinimumLength(UserValidationRules.MinUsernameLength).WithMessage($"Username must be at least {UserValidationRules.MinUsernameLength} characters long.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(UserValidationRules.MinPasswordLength).WithMessage($"Password must be at least {UserValidationRules.MinPasswordLength} characters long.");
        }
    }
}
