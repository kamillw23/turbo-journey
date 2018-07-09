using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace ihsMarkit.BookStores
{
    public static class Isbn
    {
        public static string SearchUri => "https://isbndb.com/search/books/";

        public static string XPath => "/html[1]/body[1]/div[1]/div[4]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/dl[1]/dt[4]";

        public static string GetValueFromHtmlNode(HtmlNode node)
        {
            var regexp = new Regex("\\d{13}$");
            return regexp.Match(node.InnerText).Value;
        }
    }
}