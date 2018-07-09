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
        private readonly List<IBookSite> bookStores;

        public BookRequester(List<IBookSite> bookStores)
        {
            this.bookStores = bookStores;
        }

        public async Task<List<BookPriceObject>> GetBookPrices(string title)
        {
            string bookIsbn;
            try
            {
                bookIsbn = Isbn.GetBookIsbn(title);
            }
            catch (ArgumentNullException ex)
            {
                throw new ApplicationException($"Could not find ISBN for title: {title}",ex);
            }
            catch (NullReferenceException ex)
            {
                throw new ApplicationException($"Could not find ISBN for title: {title}", ex);
            }

            var prices = new List<BookPriceObject>();

            foreach (var store in bookStores)
            {
                var bookData = await this.GetBookData(store, bookIsbn);
                if (bookData != null) prices.Add(bookData.Value);
            }

            return prices;
        }

        private async Task<HttpResponseMessage> AskForBook(IBookSite bookSite, string isbn)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "User-Agent-Here");
                return await client.GetAsync(bookSite.SearchUri + isbn);
            }
        }

        private async Task<BookPriceObject?> GetBookData(IBookSite bookSite, string isbn)
        {
            var htmlDocument = new HtmlDocument();
            var response = await this.AskForBook(bookSite, isbn);
            htmlDocument.LoadHtml(await response.Content.ReadAsStringAsync());
            var nodeWithValue = htmlDocument.DocumentNode.SelectNodes(bookSite.XPath)?.FirstOrDefault();

            try
            {
                return bookSite.GetValueFromHtmlNode(nodeWithValue);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine($"Could not find book with: {isbn} in {bookSite.GetType().Name}");
                return null;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine($"Could not find book with: {isbn} in {bookSite.GetType().Name}");
                return null;
            }
        }
    }
}