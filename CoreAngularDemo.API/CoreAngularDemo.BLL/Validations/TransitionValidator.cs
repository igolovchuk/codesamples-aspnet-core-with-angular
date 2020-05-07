using FluentValidation;
using CoreAngularDemo.BLL.DTOs;

namespace CoreAngularDemo.BLL.Validations
{
    public class CoreAngularDemoionValidator : AbstractValidator<CoreAngularDemoionDTO>
    {
        public CoreAngularDemoionValidator()
        {
            RuleFor(t => t.ActionType)
                .NotNull();
            RuleFor(t => t.FromState)
                .NotNull();
            RuleFor(t => t.ToState)
                .NotNull();
            RuleFor(t => t.ActionType.Id)
                .NotNull()
                .GreaterThan(0);
            RuleFor(t => t.FromState.Id)
                .NotNull()
                .GreaterThan(0);
            RuleFor(t => t.ToState.Id)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
