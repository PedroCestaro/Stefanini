using MediatR;
using Stefanini.Application.Common;


namespace Stefanini.Application.Models 
{
    public class DeletePersonCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }

        public DeletePersonCommand(int id)
        {
            Id = id;
        }
    }
}
