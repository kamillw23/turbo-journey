using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ihsMarkit.BookStores;

namespace ihsMarkit
{
    public class PriceParser
    {
        public int ParseBookPrice(IResponseParser parser, HttpResponseMessage response)
        {
            return parser.ParseResponse(response);
        }
    }
}
