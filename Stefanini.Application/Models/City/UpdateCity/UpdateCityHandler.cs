using MediatR;
using Stefanini.Application.Common;
using AutoMapper;
using Stefanini.Application.Interfaces;
using Stefanini.Application.Dto;


namespace Stefanini.Application.Models
{
    public class UpdateCityHandler : IRequestHandler<UpdateCityCommand, BaseResponse>
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public UpdateCityHandler(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
           BaseRequestValidation.ValidatesNullRequest(request);

            try
            {
                CityDto cityDto = _mapper.Map<UpdateCityCommand, CityDto>(request);

                await _cityService.UpdateCity(cityDto);

                return new BaseResponse(true);

            }
            catch (Exception ex)
            {
                return new BaseResponse(ex.Message);
            }
        }
    }
}
