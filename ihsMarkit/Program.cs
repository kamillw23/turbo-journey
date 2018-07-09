using ihsMarkit.BookStores;
using System;
using System.Collections.Generic;

namespace ihsMarkit
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var requester = new BookRequester(new List<IBookSite> { new Amazon(), new Apress() });
            Console.WriteLine("Write book title, to compare prices, write 'end' to exit");
            //string title = "Blockchain Enabled Applications";
            string title = Console.ReadLine();
            while (title != "end")
            {        
                var chepest = PriceComparer.GetCheapest(requester.GetBookPrices(title).Result);
                Console.WriteLine(chepest);
                title = Console.ReadLine();
            }
        }
    }
}