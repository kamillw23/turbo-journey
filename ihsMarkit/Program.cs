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
                if (string.IsNullOrEmpty(title))
                {
                    Console.WriteLine("Title is empty, please enter title or write 'end' to finish work");
                }
                else
                {
                    Console.WriteLine(PriceComparer.GetCheapest(requester.GetBookPrices(title).Result));
                }
                
                title = Console.ReadLine();
            }
        }
    }
}