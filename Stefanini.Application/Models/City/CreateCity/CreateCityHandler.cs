using MediatR;
using Stefanini.Application.Common;
using AutoMapper;
using Stefanini.Application.Interfaces;
using Stefanini.Application.Dto;
using Stefanini.Application.Models.Dto.Validations;

namespace Stefanini.Application.Models
{
    public class CreateCityHandler : IRequestHandler<CreateCityCommand, BaseResponse>
    {
        private readonly ICityService _cityService; 
        private readonly IMapper _mapper;    

        public CreateCityHandler(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }


        public async Task<BaseResponse> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            BaseRequestValidation.ValidatesNullRequest(request);

            try
            {
                var cityDto = _mapper.Map<CityDto>(request);

                ValidateInformations(cityDto);

                await _cityService.CreateNewCity(cityDto);

                return new BaseResponse(true);
            }
            catch (Exception ex)
            {
                return new BaseResponse(ex.Message);
            }
        }


        private void ValidateInformations(CityDto cityDto)
        {
            CityDtoValidation validator = new CityDtoValidation();
            var validation = validator.Validate(cityDto);
            if (validation.Errors.Any())
                throw new ArgumentException(validation.Errors.FirstOrDefault().ErrorMessage);
        }
    }
}
