using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace ihsMarkit.BookStores
{
    public class Apress : IBookSite
    {
        public string SearchUri => "https://www.apress.com/de/book/";

        public string XPath => "/html[1]/body[1]/div[2]/div[2]/div[2]/div[1]/div[2]/div[1]/dl[1]";


        public BookPriceObject GetValueFromHtmlNode(HtmlNode htmlNode)
        {
            var dtNodes = htmlNode.ChildNodes.Where(node => node.OriginalName == "dt");
            var softCoverNode = dtNodes.FirstOrDefault(node => node.InnerText.Contains("Softcover"));
            var text = softCoverNode?.SelectNodes(softCoverNode.XPath + "/span[2]/span[1]").FirstOrDefault()?.InnerText;
            var bookPrice = Regex.Match(text, "\\d*[.]\\d*").Value;
            return new BookPriceObject { Store = this.ToString(), Price = decimal.Parse(bookPrice), Currency = Currency.Euro };
        }
    }
}