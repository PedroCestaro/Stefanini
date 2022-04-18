using MediatR;
using Stefanini.Application.Common;

namespace Stefanini.Application.Models
{
    public class DeleteCityCommandt: IRequest<BaseResponse>
    {
        public int Id { get; set; }

        public DeleteCityCommandt(int id)
        {
            Id = id;
        }
    }
}
