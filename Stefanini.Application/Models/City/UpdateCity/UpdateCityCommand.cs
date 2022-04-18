using MediatR;
using Stefanini.Application.Common;

namespace Stefanini.Application.Models
{
    public class UpdateCityCommand : IRequest<BaseResponse>
    {
        public int Id   { get; set; }
        public string Name { get; set; }
        public string Uf { get; set; }  
    }
}
