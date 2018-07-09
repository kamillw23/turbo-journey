using System;
using System.Net.Http;
using HtmlAgilityPack;

namespace ihsMarkit.BookStores
{
    public class Isbn : IBookStore
    {
        public string SearchUri => "https://isbndb.com/search/books/";

        public string XPath => "/html[1]/body[1]/div[1]/div[4]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/dl[1]/dt[1]";

        public int GetValueFromHtmlNode(HtmlNode node)
        {
            throw new NotImplementedException();
        }
    }
}