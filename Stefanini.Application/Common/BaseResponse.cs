

namespace Stefanini.Application.Common
{
    public class BaseResponse
    {
        public bool Success { get; set; }

        public string Error { get; set; }

        public BaseResponse(bool response)
        {
            Success = response;
        }

        public BaseResponse(string error)
        {
            Error = error;
        }

        public BaseResponse() { }
    }
}
