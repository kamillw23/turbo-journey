using System;
using System.Net.Http;
using HtmlAgilityPack;

namespace ihsMarkit.BookStores
{
    public class Isbn : AbstractBookStore
    {
        internal Isbn()
        {
            this.searchUri = "https://isbndb.com/search/books/";
        }

        public int ParseResponse(HtmlDocument document)
        {
            throw new NotImplementedException();
        }
    }
}