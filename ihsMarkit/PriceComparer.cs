using System.Collections.Generic;

namespace ihsMarkit
{
    public static class PriceComparer
    {
        public static BookPriceObject GetCheapest(List<BookPriceObject> books)
        {
            books.Sort();
            return books[0];
        }
    }
}