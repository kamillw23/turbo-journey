using System;
using System.Net.Http;
using HtmlAgilityPack;

namespace ihsMarkit.BookStores
{
    public class Isbn : AbstractBookStore
    {
        internal Isbn()
        {
            this.searchUri = "https://isbndb.com/search/books/";
            this.xPath = "/html[1]/body[1]/div[1]/div[4]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/dl[1]/dt[1]";
        }

        protected override int GetValueFromHtmlNode(HtmlNode node)
        {
            throw new NotImplementedException();
        }
    }
}