
namespace Stefanini.Application.Common
{
    public static class BaseRequestValidation
    {
        public static void ValidatesNullRequest(object request)
        {
            if (request.Equals(null))
                throw new ArgumentNullException(nameof(request));
        }

        public static void ValidateNullValue(int request)
        {
            if (request.Equals(null))
                throw new ArgumentNullException(nameof(request));
        }
    }
}
