using Microsoft.AspNetCore.Mvc;
using MediatR;
using Stefanini.Application.Interfaces;
using Stefanini.Application.Models;

namespace Stefanini.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        private readonly IPersonService _personService;
        private readonly IMediator _mediator;

        public PersonController(IPersonService personService, IMediator mediator)
        {
            _personService = personService;
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _personService.GetAllPersons());
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
                var request = new GetPersonByIdQuery(id);
                return Ok( await _mediator.Send(request));
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
        public async Task<IActionResult> Post([FromBody] CreatePersonCommand request)
        {
            try
            {
                return Ok( await _mediator.Send(request));
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
        public async Task<IActionResult> Put([FromBody] UpdatePersonCommand request)
        {
            try
            {
                return Ok( await _mediator.Send(request));
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
                return Ok(await _mediator.Send(new DeletePersonCommand(id)));
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
