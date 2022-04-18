using MediatR;
using Stefanini.Application.Interfaces;
using Stefanini.Application.Dto;
using AutoMapper;
using Stefanini.Application.Common;

namespace Stefanini.Application.Models
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, BaseResponse>
    {
        private readonly IPersonService _personService;
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public CreatePersonHandler(IPersonService personService, IMapper mapper, ICityService cityService)
        {
            _cityService = cityService;
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            BaseRequestValidation.ValidatesNullRequest(request);

            VerifiesIfCityIsRegistered(request.CityId);

            try
            {
                PersonDto dto = _mapper.Map<CreatePersonCommand, PersonDto>(request);

                await _personService.CreateNewPerson(dto);

                return new BaseResponse(true);

            }
            catch (Exception ex)
            {
                return new BaseResponse(ex.Message);
            }
        }

        private void VerifiesIfCityIsRegistered(int cidadeId)
        {
            var city = _cityService.GetCityById(cidadeId);
            if (city.Equals(null))
                throw new ArgumentException("Cidade especificada, não foi encontrada");
        } 
    }
}
