using System.Collections.Generic;

namespace ihsMarkit
{
    public static class PriceComparer
    {
        public static string GetCheapest(List<BookPriceObject> books)
        {
            if (books == null || books.Count == 0) return "";
            books.Sort();
            return books[0].ToString();
        }
    }
}