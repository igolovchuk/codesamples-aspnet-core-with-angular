using FluentValidation;
using CoreAngularDemo.BLL.DTOs;

namespace CoreAngularDemo.BLL.Validations
{
    public class PartValidator : AbstractValidator<PartDTO>
    {
        public PartValidator()
        {
            RuleFor(p => p.Unit)
                .NotNull()
                .NotEmpty();
            RuleFor(p => p.Manufacturer)
                .NotNull()
                .NotEmpty();
        }
    }
}