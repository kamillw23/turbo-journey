using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ihsMarkit.BookStores
{
    class Amazon : IBookSite
    {
        public string SearchUri => "https://www.amazon.de/gp/search/?field-isbn=";

        public string XPath => "/html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/div[2]/div[1]/div[4]/div[1]/div[1]/ul[1]/li[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[2]/a[1]/span[1]";

        public BookPriceObject GetValueFromHtmlNode(HtmlNode node)
        {
            var price = Regex.Match(node.InnerText, "\\d*[.]\\d*").Value;
            return new BookPriceObject {Store = this.ToString(), Price = decimal.Parse(price), Currency = Currency.Euro};
        }

    }
}
