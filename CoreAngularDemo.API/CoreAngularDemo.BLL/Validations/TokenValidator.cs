using FluentValidation;
using CoreAngularDemo.BLL.DTOs;

namespace CoreAngularDemo.BLL.Validations
{
    public class TokenValidator : AbstractValidator<TokenDTO>
    {
        public TokenValidator()
        {
            RuleFor(t => t.AccessToken)
                .NotNull()
                .NotEmpty();
            RuleFor(t => t.RefreshToken)
                .NotNull()
                .NotEmpty();
        }
    }
}