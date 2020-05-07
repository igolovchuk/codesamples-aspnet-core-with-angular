using FluentValidation;
using CoreAngularDemo.BLL.DTOs;

namespace CoreAngularDemo.BLL.Validations
{
    public class MalfunctionGroupValidator : AbstractValidator<MalfunctionGroupDTO>
    {
        public MalfunctionGroupValidator()
        {
            RuleFor(t => t.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}
