using HtmlAgilityPack;
using System.Net.Http;
using System.Threading.Tasks;

namespace ihsMarkit.BookStores
{
    public interface IBookSite
    {
        string SearchUri { get; }

        string XPath { get; }

        BookPriceObject GetValueFromHtmlNode(HtmlNode htmlNode);
    }
}