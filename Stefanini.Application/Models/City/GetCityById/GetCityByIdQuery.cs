using MediatR;

namespace Stefanini.Application.Models
{
    public class GetCityByIdQuery : IRequest<GetCityByIdResponse>
    {
        public int Id { get; set; }

        public GetCityByIdQuery(int id)
        {
            Id = id;
        }
    }
}
