using System.Net.Http;
using System.Threading.Tasks;

namespace ihsMarkit.BookStores
{
    public interface IBookStore
    {
        string GetSearchUri(string title);

        Task<int> ParseResponse(HttpResponseMessage response);
    }
}