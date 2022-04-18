using MediatR;
using Stefanini.Application.Common;
using Stefanini.Application.Interfaces;
using AutoMapper;

namespace Stefanini.Application.Models
{
    public class DeleteCityHandler : IRequestHandler<DeleteCityCommandt, BaseResponse>
    {
        private readonly ICityService _cityService;

        public DeleteCityHandler(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<BaseResponse> Handle(DeleteCityCommandt request, CancellationToken cancellationToken)
        {
            BaseRequestValidation.ValidateNullValue(request.Id);

            try
            {
                await _cityService.DeleteCity(request.Id);
                return new BaseResponse(true);
            }
            catch (Exception ex)
            {
                return new BaseResponse(ex.Message);
            }
        }
    }
}
