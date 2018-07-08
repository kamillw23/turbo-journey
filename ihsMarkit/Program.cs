using System;
using System.Net.Http;
using HtmlAgilityPack;

namespace ihsMarkit
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Write book title, to compare prices, write 'end' to exit");
            string userInput = String.Empty;
            /* while (userInput != "end")
             {
                 userInput = Console.ReadLine();
                 using (var requester = new BookRequester())
                 {

                 }
             }*/

            var ggg = new HttpClient();
            //ggg.DefaultRequestHeaders.Add("User-Agent", "User-Agent-Here");
            //var ttt = ggg.GetAsync("https://isbnsearch.org/").Result;
            //HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://isbnsearch.org/search?s=fellowship+of+the+ring");
            //HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://www.amazon.com/gp/search/?field-isbn=9780547928210");
            // HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://www.apress.com/us/book/9781484237205");
            // Add our custom headers
            //HttpResponseMessage response = ggg.GetAsync("https://www.apress.com/us/book/9781484237205").Result;
            HttpResponseMessage response =
                ggg.GetAsync("https://isbndb.com/search/books/fellowship of the ring").Result;
            //kkk.Navigate(new Uri("https://www.apress.com/us/book/9781484237205"));
            /*kkk.Navigate(new Uri("https://isbnsearch.org/search?s=fellowship+of+the+ring"));
            while (kkk.ReadyState != WebBrowserReadyState.Complete)
            { Application.DoEvents(); }

            var ddd = kkk.Document.DomDocument.ToString();*/

            var fff = response.Content.ReadAsStringAsync().Result;
            //XDocument hhh = XDocument.Parse(fff);
            var iii = new HtmlDocument();

            iii.LoadHtml(fff);
            var gghg = iii.DocumentNode.SelectNodes(
                "//html[1]/body[1]/div[1]/div[4]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/dl[1]/dt[1]");
            //var ddd = JObject.Parse(fff);
            //var ttty = response.Headers.
            Console.WriteLine(gghg);
            //Console.WriteLine(ddd);
        }
    }
}