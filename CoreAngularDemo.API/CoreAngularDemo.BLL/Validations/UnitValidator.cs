using FluentValidation;
using CoreAngularDemo.BLL.DTOs;

namespace CoreAngularDemo.BLL.Validations
{
    public class UnitValidator : AbstractValidator<UnitDTO>
    {
        public UnitValidator()
        {
            RuleFor(u => u.Name)
                .NotNull()
                .NotEmpty();
            RuleFor(u => u.ShortName)
                .NotNull()
                .NotEmpty();
        }
    }
}