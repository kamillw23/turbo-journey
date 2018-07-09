using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ihsMarkit.BookStores;

namespace ihsMarkit
{
    public class BookRequester
    {
        private readonly List<IBookSite> bookStores;

        public BookRequester(List<IBookSite> bookStores)
        {
            this.bookStores = bookStores;
        }

        public async Task<List<BookPriceObject>> GetBookPrices(string title)
        {
            var isbn = new Isbn();
            var bookIsbn = this.GetBookData(isbn, title);

            var prices = new List<BookPriceObject>();

            foreach (var store in bookStores)
            {
                prices.Add(this.GetBookData(store, await bookIsbn).Result);
            }

            return prices;
        }

        private async Task<HttpResponseMessage> AskForBook(IBookSite bookSite, string title)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "User-Agent-Here");
                return await client.GetAsync(bookSite.SearchUri + title);
            }
        }

        private async Task<BookPriceObject> GetBookData(IBookSite bookSite, string title)
        {
            var htmlDocument = new HtmlDocument();
            var response = this.AskForBook(bookSite, title).Result;
            htmlDocument.LoadHtml(await response.Content.ReadAsStringAsync());
            var nodeWithValue = htmlDocument.DocumentNode.SelectNodes(bookSite.XPath)?.FirstOrDefault();

            return bookSite.GetValueFromHtmlNode(nodeWithValue);
        }
    }
}