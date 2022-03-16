using System;
using System.Net.Http;
using System.Threading.Tasks;
namespace ticker.project2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("This application will give you your standard stock information based off the ticker symbol");

            Console.WriteLine("Enter the ticker symbol:");

            string tickerSymbol = Console.ReadLine();

            if(!string.IsNullOrEmpty(tickerSymbol))
            {
            tickerSymbol = tickerSymbol.ToUpper().Trim();
            // get stock info
            // https://api.polygon.io/v1/open-close/AAPL/2020-10-14?adjusted=true&apiKey=ypEb3yp_rdTYuYOjCf5cSn3kYBEsj5CB
            // create stock class
            


            try{
            HttpClient stockApiClinet = new HttpClient();
            var response = await stockApiClinet.GetAsync("https://api.polygon.io/v1/open-close/AAPL/2020-10-14?adjusted=true&apiKey=ypEb3yp_rdTYuYOjCf5cSn3kYBEsj5CB")  ;
           string responseBody = await response.Content.ReadAsStringAsync();
           Console.WriteLine(responseBody);
            }
    
            catch 
            {

            }

        }
        }
    }
}

