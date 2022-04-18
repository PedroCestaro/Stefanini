using Stefanini.Application.Common;

namespace Stefanini.Application.Models
{
    public class GetCityByIdResponse : BaseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uf { get; set; }

        public GetCityByIdResponse()
        {

        }
        public GetCityByIdResponse(string error) : base(error)
        {

        }
    }
}
