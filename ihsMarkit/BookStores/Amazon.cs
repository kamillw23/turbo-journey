using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ihsMarkit.BookStores
{
    class Amazon : AbstractBookStore
    {
        internal Amazon()
        {
            this.searchUri = "https://www.amazon.com/gp/search/?field-isbn=";
        }

        public int ParseResponse(HttpResponseMessage response)
        {
            throw new NotImplementedException();
        }

        string GetSearchUri(string title)
        {
            throw new NotImplementedException();
        }
    }
}
