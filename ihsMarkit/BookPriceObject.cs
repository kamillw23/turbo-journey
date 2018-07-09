using System;

namespace ihsMarkit
{
    public struct BookPriceObject : IComparable<BookPriceObject>
    {
        public string Store;

        public decimal Price;

        public Currency Currency;

        public int CompareTo(BookPriceObject other)
        {
            return Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return $"Store: {this.Store}, Price: {Price}{Currency}";
        }
    }
}