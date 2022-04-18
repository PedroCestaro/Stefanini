using MediatR;
using Stefanini.Application.Common;
using Stefanini.Application.Interfaces;
using AutoMapper;
using Stefanini.Application.Dto;

namespace Stefanini.Application.Models
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, BaseResponse>
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public UpdatePersonHandler(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }


        public async Task<BaseResponse> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            BaseRequestValidation.ValidatesNullRequest(request);

            try
            {
                var personDto = _mapper.Map<PersonDto>(request);

                await _personService.UpdatePerson(personDto);

                return new BaseResponse(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
