using MediatR;
using Stefanini.Application.Common;

namespace Stefanini.Application.Models
{
    public class UpdatePersonCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public int Age { get; set; }
        public int CityId { get; set; }
    }
}
