using System;
using System.Net.Http;

namespace ihsMarkit.BookStores
{
    public class Apress : AbstractBookStore
    {
        internal Apress()
        {
            this.searchUri = "https://www.apress.com/us/book/";
        }

        public int ParseResponse(HttpResponseMessage response)
        {
            throw new NotImplementedException();
        }

        public string GetSearchUri(string title)
        {
            throw new NotImplementedException();
        }
    }
}