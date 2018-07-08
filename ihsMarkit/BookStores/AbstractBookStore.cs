using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ihsMarkit.BookStores
{
    public abstract class AbstractBookStore : IBookStore
    {
        protected string searchUri;

        protected string xPath;

        public virtual string GetSearchUri(string title)
        {
            return searchUri + title;
        }

        public async Task<int> ParseResponse(HttpResponseMessage response)
        {
            var iii = new HtmlDocument();

            iii.LoadHtml(await response.Content.ReadAsStringAsync());
            var gghg = iii.DocumentNode.SelectNodes(this.xPath)?.FirstOrDefault();

            return this.GetValueFromHtmlNode(gghg);
        }

        protected abstract int GetValueFromHtmlNode(HtmlNode node);
    }
}