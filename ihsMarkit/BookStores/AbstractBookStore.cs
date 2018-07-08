using System;
using System.Net.Http;

namespace ihsMarkit.BookStores
{
    public abstract class AbstractBookStore : IBookStore, IResponseParser
    {
        protected string searchUri;

        public virtual string GetSearchUri(string title)
        {
            throw new NotImplementedException();
        }

        public virtual int ParseResponse(HttpResponseMessage response)
        {
            throw new NotImplementedException();
        }
    }
}