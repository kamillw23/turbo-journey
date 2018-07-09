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
            Console.WriteLine("Write book title, to compare prices, write 'end' to exit\n");
            string title = Console.ReadLine();

            while (title != "end")
            {
                if (string.IsNullOrEmpty(title))
                {
                    Console.WriteLine("Title is empty, please enter title or write 'end' to finish work\n");
                }
                else
                {
                    List<BookPriceObject> bookPrices;

                    try
                    {
                        bookPrices = requester.GetBookPrices(title).Result;
                    }
                    catch (AggregateException ex)
                    {
                        if (ex.InnerException.GetType() == typeof(ApplicationException))
                        {
                            Console.WriteLine(ex.InnerException.Message);
                            bookPrices = null;
                        }
                        else
                        {
                            throw;
                        }
                    }

                    Console.WriteLine(PriceComparer.GetCheapest(bookPrices) + "\n");
                }

                Console.WriteLine("Enter book title or 'end' to exit");
                title = Console.ReadLine();
            }
        }
    }
}