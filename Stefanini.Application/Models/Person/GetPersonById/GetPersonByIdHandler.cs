using MediatR;
using Stefanini.Application.Interfaces;
using AutoMapper;
using Stefanini.Application.Common;
using Stefanini.Application.Dto;

namespace Stefanini.Application.Models
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, GetPersonByIdResponse>
    {

        private readonly IPersonService _personService;
        private readonly IMapper _mapper;   

        public GetPersonByIdHandler(IPersonService personService, IMapper mapper)
        {
            _personService = personService; 
            _mapper = mapper;
        }

        public async Task<GetPersonByIdResponse> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            BaseRequestValidation.ValidatesNullRequest(request);
            try
            {
                var person = await _personService.GetPersonById(request.Id);

                if (person == null)
                    throw new Exception("Pessoa não encontrada");

                var result = _mapper.Map<GetPersonByIdResponse>(person);

                return result;
            }
            catch (Exception ex)
            {
                return new GetPersonByIdResponse(ex.Message);
            }
        }
    }
}
