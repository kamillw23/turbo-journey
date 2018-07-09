using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ihsMarkit.BookStores
{
    class Amazon : IBookStore
    {
        public string SearchUri => "https://www.amazon.com/gp/search/?field-isbn=";

        public string XPath => throw new NotImplementedException();

        public int GetValueFromHtmlNode(HtmlNode node)
        {
            throw new NotImplementedException();
        }

    }
}
