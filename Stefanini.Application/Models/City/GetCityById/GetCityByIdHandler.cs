using MediatR;
using Stefanini.Application.Interfaces;
using AutoMapper;
using Stefanini.Application.Common;

namespace Stefanini.Application.Models
{
    public class GetCityByIdHandler : IRequestHandler<GetCityByIdQuery, GetCityByIdResponse>
    {
        private readonly ICityService _cityService; 
        private readonly IMapper _mapper;    

        public GetCityByIdHandler(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }


        public async Task<GetCityByIdResponse> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            BaseRequestValidation.ValidateNullValue(request.Id);
            try
            {
                var city = await _cityService.GetCityById(request.Id);

                if (city == null)
                    throw new Exception("Cidade não encontrada");

                return _mapper.Map<GetCityByIdResponse>(city);
            }
            catch (Exception ex)
            {
                return new GetCityByIdResponse(ex.Message);
            }
            
        }
    }
}
