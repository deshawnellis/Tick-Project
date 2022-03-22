using System;
namespace ticker.project2.Models
{
    public class StockOpenClose
    {
        public StockOpenClose()
        {
        }

        public string status { get; set; }
        public string from { get; set; }
        public string symbol { get; set; }
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public int volume { get; set; }
        public double afterHours { get; set; }
        public double preMarket { get; set; }
    }
}
