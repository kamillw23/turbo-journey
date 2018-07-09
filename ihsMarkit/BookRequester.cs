using HtmlAgilityPack;
using ihsMarkit.BookStores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ihsMarkit
{
    public class BookRequester
    {
        private readonly List<IBookStore> bookStores;

        public BookRequester(List<IBookStore> bookStores)
        {
            this.bookStores = bookStores;
        }

        public async Task<Dictionary<string, int>> GetBookPrices(string title)
        {
            var isbn = new Isbn();
            var bookIsbn = this.ParseResponse(isbn, await this.AskForBook(isbn, title));

            return null;
        }

        public async Task<HttpResponseMessage> AskForBook(IBookStore bookSite, string title)
        {
            using (var client = new HttpClient())
            {
                return await client.GetAsync(bookSite.SearchUri + title);
            }  
        }

        public async Task<int> ParseResponse(IBookStore bookSite, HttpResponseMessage response)
        {
            var htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(await response.Content.ReadAsStringAsync());
            var nodeWithValue = htmlDocument.DocumentNode.SelectNodes(bookSite.XPath)?.FirstOrDefault();

            return bookSite.GetValueFromHtmlNode(nodeWithValue);
        }
    }
}