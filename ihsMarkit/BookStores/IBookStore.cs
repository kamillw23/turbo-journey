using HtmlAgilityPack;
using System.Net.Http;
using System.Threading.Tasks;

namespace ihsMarkit.BookStores
{
    public interface IBookStore
    {
        string SearchUri { get; }

        string XPath { get; }

        int GetValueFromHtmlNode(HtmlNode htmlNode);
    }
}