using DiarioDelGelato.Application.DTOs.Identity;
using FluentValidation;

namespace DiarioDelGelato.Application.Validators.Identity
{
    public class RevoqueTokenRequestValidator : AbstractValidator<RevokeTokenRequestDTO>
    {
        public RevoqueTokenRequestValidator()
        {
            RuleFor(x => x.Token)
                .NotEmpty().WithMessage("Token is required")
                .Must(BeAValidToken).WithMessage("Token is invalid");
        }

        private bool BeAValidToken(string token)
        {
            //future implementation to validate the token at TokenService
            return true;
        }
    }
}
