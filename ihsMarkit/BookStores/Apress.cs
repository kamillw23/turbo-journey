using System;
using System.Net.Http;
using HtmlAgilityPack;

namespace ihsMarkit.BookStores
{
    public class Apress : IBookStore
    {
        public string SearchUri => "https://www.apress.com/us/book/";

        public string XPath => throw new NotImplementedException();

        public int GetValueFromHtmlNode(HtmlNode htmlNode)
        {
            throw new NotImplementedException();
        }
    }
}