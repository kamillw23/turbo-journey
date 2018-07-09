using HtmlAgilityPack;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace ihsMarkit.BookStores
{
    public static class Isbn
    {
        private static string SearchUri => "https://isbndb.com/search/books/";

        private static string XPath => "/html[1]/body[1]/div[1]/div[4]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/dl[1]/dt[4]";

        private static string GetValueFromHtmlNode(HtmlNode node)
        {
            var regexp = new Regex("\\d{13}$");
            return regexp.Match(node.InnerText).Value;
        }

        public static string GetBookIsbn(string title)
        {
            HttpResponseMessage isbnResposne;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "User-Agent-Here");
                isbnResposne = client.GetAsync(Isbn.SearchUri + title).Result;
            }

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(isbnResposne.Content.ReadAsStringAsync().Result);
            var nodeWithValue = htmlDocument.DocumentNode.SelectNodes(Isbn.XPath)?.FirstOrDefault();

            return Isbn.GetValueFromHtmlNode(nodeWithValue);
        }
    }
}