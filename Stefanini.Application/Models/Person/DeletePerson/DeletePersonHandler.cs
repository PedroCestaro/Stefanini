using MediatR;
using Stefanini.Application.Common;
using Stefanini.Application.Interfaces;

namespace Stefanini.Application.Models
{
    public class DeletePersonHandler : IRequestHandler<DeletePersonCommand, BaseResponse>
    {
        private readonly IPersonService _personService;

        public DeletePersonHandler(IPersonService personService)
        {
            _personService = personService;
        } 


        public async Task<BaseResponse> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            BaseRequestValidation.ValidateNullValue(request.Id);

            try
            {
                await _personService.DeletePerson(request.Id);

                return new BaseResponse(true);
            }
            catch (Exception ex)
            {
                return new BaseResponse(ex.Message);
            }
        }
    }
}
