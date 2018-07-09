using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ihsMarkit.BookStores
{
    internal class Amazon : IBookSite
    {
        public string SearchUri => "https://www.amazon.de/gp/search/?field-isbn=";

        public string XPath => "/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/div[2]/div[1]/div[4]/div[1]/div[1]/ul[1]/li[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/a[1]/span[1]";

        public BookPriceObject GetValueFromHtmlNode(HtmlNode node)
        {
            var price = Regex.Match(node.InnerText, "\\d*[,]\\d*").Value;
            return new BookPriceObject { Store = "Amazon", Price = decimal.Parse(price), Currency = Currency.Euros };
        }
    }
}