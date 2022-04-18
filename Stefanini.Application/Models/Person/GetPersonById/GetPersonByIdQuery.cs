using MediatR;

namespace Stefanini.Application.Models
{
    public class GetPersonByIdQuery : IRequest<GetPersonByIdResponse>
    {
        public int Id { get; set; }

        public GetPersonByIdQuery(int id)
        {
            Id = id;
        }
    }
}
