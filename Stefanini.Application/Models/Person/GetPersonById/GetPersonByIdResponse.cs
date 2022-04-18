using Stefanini.Application.Dto;
using Stefanini.Application.Common;

namespace Stefanini.Application.Models
{
    public class GetPersonByIdResponse : BaseResponse
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public int Age { get; set; }
        public int CityId { get; set; }
        public CityDto City { get; set; }

        public GetPersonByIdResponse()
        {

        }

        public GetPersonByIdResponse(string error) : base(error)
        {
        }
    }
}
