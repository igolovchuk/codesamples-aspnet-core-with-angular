using FluentValidation;
using CoreAngularDemo.BLL.DTOs;

namespace CoreAngularDemo.BLL.Validations
{
    public class StateValidator : AbstractValidator<StateDTO>
    {
        public StateValidator()
        {
            RuleFor(t => t.TransName)
                .NotNull()
                .NotEmpty();
        }
    }
}
