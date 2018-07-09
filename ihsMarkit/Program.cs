using System;
using System.Collections.Generic;
using ihsMarkit.BookStores;

namespace ihsMarkit
{
    class Program
    {
        static void Main(string[] args)
        {
            var requester = new BookRequester(new List<IBookSite> {new Amazon(), new Apress()});
            Console.WriteLine("Write book title, to compare prices, write 'end' to exit");
            string title = "Blockchain Enabled Applications";
            while (title != "end")
            {
                //title = Console.ReadLine();
                var fff = requester.GetBookPrices(title).Result;
            }
        }
    }
}