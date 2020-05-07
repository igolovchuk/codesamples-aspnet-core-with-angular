using FluentValidation;
using CoreAngularDemo.BLL.DTOs;

namespace CoreAngularDemo.BLL.Validations
{
    public class MalfunctionSubgroupValidator : AbstractValidator<MalfunctionSubgroupDTO>
    {
        public MalfunctionSubgroupValidator()
        {
            RuleFor(t => t.Name)
                .NotNull()
                .NotEmpty();
            RuleFor(t => t.MalfunctionGroup)
                .NotNull();
            RuleFor(t => t.MalfunctionGroup.Id)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
