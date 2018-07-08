using System.Net.Http;

namespace ihsMarkit.BookStores
{
    public interface IResponseParser
    {
        int ParseResponse(HttpResponseMessage response);
    }
}