using System;
using System.Net.Http;
using System.Threading.Tasks;
using ihsMarkit.BookStores;

namespace ihsMarkit
{
    public class BookRequester : IDisposable
    {
        private readonly HttpClient client;

        public BookRequester()
        {
            this.client = new HttpClient();
        }

        public void Dispose()
        {
            this.client.Dispose();
        }

        public async Task<HttpResponseMessage> AskForBook(IBookStore bookSite, string title)
        {
            return await this.client.GetAsync(bookSite.GetSearchUri(title));
        }
    }
}