using FluentValidation;
using CoreAngularDemo.BLL.DTOs;

namespace CoreAngularDemo.BLL.Validations
{
    public class ActionTypeValidator : AbstractValidator<ActionTypeDTO>
    {
        public ActionTypeValidator()
        {
            RuleFor(t => t.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}
