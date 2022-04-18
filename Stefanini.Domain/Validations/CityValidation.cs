using FluentValidation;
using Stefanini.Domain.Aggregates;

namespace Stefanini.Domain.Validations
{
    public class CityValidation : AbstractValidator<City>
    {
        public CityValidation()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull().MinimumLength(1).MaximumLength(200);
            RuleFor(c => c.Uf).MaximumLength(2).NotEmpty().NotNull();
        }
    }
}
