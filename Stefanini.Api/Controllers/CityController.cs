using Microsoft.AspNetCore.Mvc;
using MediatR;
using Stefanini.Application.Interfaces;
using Stefanini.Application.Models;

namespace Stefanini.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : BaseController
    {
        private readonly ICityService _cityService;
        private readonly IMediator _mediator;

        public CityController(ICityService cityService, IMediator mediator)
        {
            _cityService = cityService;
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _cityService.GetAllCities());
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var request = new GetCityByIdQuery(id);
                return Ok(await _mediator.Send(request));
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCityCommand request)
        {
            try
            {
                return Ok(await _mediator.Send(request));
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCityCommand request)
        {
            try
            {
                return Ok(await _mediator.Send(request));
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _mediator.Send(new DeleteCityCommandt(id)));
            }
            catch (ArgumentException ex)
            {
                return ArgumentExceptionHandling(ex);
            }
            catch (Exception ex)
            {
                return ExceptionHandling(ex);
            }
        }

    }
}
