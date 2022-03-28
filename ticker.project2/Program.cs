using System;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BetterConsoleTables;
using Newtonsoft.Json;
using ticker.project2.Models;

namespace ticker.project2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            bool continueApplication = true;


            Console.WriteLine("This application will give you your standard stock information based off the ticker symbol");


            while (continueApplication)
            {

                Console.WriteLine("Enter the ticker symbol:");

                //Get the stock the user has typed in
                string tickerSymbol = Console.ReadLine();

                if (!string.IsNullOrEmpty(tickerSymbol))
                {
                    tickerSymbol = tickerSymbol.ToUpper().Trim();
                    // get stock info
                    // https://api.polygon.io/v1/open-close/AAPL/2020-10-14?adjusted=true&apiKey=ypEb3yp_rdTYuYOjCf5cSn3kYBEsj5CB
                    // https://api.polygon.io/v3/reference/tickers/AAPL?apiKey=ypEb3yp_rdTYuYOjCf5cSn3kYBEsj5CB
                    // create stock class



                    try
                    {

                        // ***await is to allow the action to continue without waiting for the results - async programming

                        HttpClient stockApiClinet = new HttpClient();
                        var response = await stockApiClinet.GetAsync($"https://api.polygon.io/v1/open-close/{tickerSymbol}/2020-10-14?adjusted=true&apiKey=ypEb3yp_rdTYuYOjCf5cSn3kYBEsj5CB");
                        var response2 = await stockApiClinet.GetAsync($"https://api.polygon.io/v3/reference/tickers/{tickerSymbol}?apiKey=ypEb3yp_rdTYuYOjCf5cSn3kYBEsj5CB");
                        var openCloseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<StockOpenClose>(await response.Content.ReadAsStringAsync());
                        var stockDetailData = JsonConvert.DeserializeObject<DetailResult>(await response2.Content.ReadAsStringAsync());



                        var columns = new string[] { "Stock Information", "Market Info", "Misc." };
                        Table table = new Table(Alignment.Center, Alignment.Center, columns);
                        table.AddRow($"Stock Name: {stockDetailData.results.name}", $"Last Market Price: {openCloseObject.close.ToString("C")}", $"Employees: {stockDetailData.results.total_employees}")
                             .AddRow($"Ticker Symbol: {openCloseObject.symbol}", "short text", "word");=

                        Console.Write(table.ToString());


                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }

                Console.WriteLine("Do you want to continue? Y or N");
                var answer = Console.ReadLine();

                if (answer.ToLower() != "y")
                {
                    continueApplication = false;
                }

            }

            return;
            
        }
    }
}

