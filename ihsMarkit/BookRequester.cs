﻿using HtmlAgilityPack;
using ihsMarkit.BookStores;
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
            var bookIsbn = Isbn.GetBookIsbn(title);

            var prices = new List<BookPriceObject>();

            foreach (var store in bookStores)
            {
                prices.Add(await this.GetBookData(store, bookIsbn));
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

        private async Task<BookPriceObject> GetBookData(IBookSite bookSite, string isbn)
        {
            var htmlDocument = new HtmlDocument();
            var response = this.AskForBook(bookSite, isbn).Result;
            htmlDocument.LoadHtml(await response.Content.ReadAsStringAsync());
            var nodeWithValue = htmlDocument.DocumentNode.SelectNodes(bookSite.XPath)?.FirstOrDefault();

            return bookSite.GetValueFromHtmlNode(nodeWithValue);
        }
    }
}