using FluentValidation;
using CoreAngularDemo.BLL.DTOs;

namespace TCoreAngularDemo.BLL.Validations
{
    public class CountryValidator : AbstractValidator<CountryDTO>
    {
        public CountryValidator()
        {
            RuleFor(t => t.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}
