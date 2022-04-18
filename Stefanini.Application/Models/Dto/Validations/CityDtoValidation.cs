using FluentValidation;
using Stefanini.Application.Dto;

namespace Stefanini.Application.Models.Dto.Validations
{
    public class CityDtoValidation : AbstractValidator<CityDto>
    {
        public CityDtoValidation()
        {
            RuleFor(x => x.Uf).MaximumLength(2).NotEmpty().NotNull();
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(200).MinimumLength(1);
        }
    }
}
