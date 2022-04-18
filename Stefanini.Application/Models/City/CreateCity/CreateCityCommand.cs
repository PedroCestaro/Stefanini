using MediatR;
using Stefanini.Application.Common;

namespace Stefanini.Application.Models
{
    public class CreateCityCommand : IRequest<BaseResponse>
    {
        public String Name { get; set; }
        public String Uf { get; set; }
    }
}
