using FluentValidation;
using CoreAngularDemo.BLL.DTOs;

namespace CoreAngularDemo.BLL.Validations
{
    public class ManufacturerValidator : AbstractValidator<ManufacturerDTO>
    {
        public ManufacturerValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .NotNull();
        }
    }
}