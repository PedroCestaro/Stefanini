using FluentValidation;
using Stefanini.Domain.Aggregates;

namespace Stefanini.Domain.Validations
{
    public class PersonValidation : AbstractValidator<Person>
    {
        public PersonValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(300).MinimumLength(1);
            RuleFor(x => x.Cpf).NotEmpty().NotNull().MaximumLength(11);
            RuleFor(x => x.Age).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.CityId).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
