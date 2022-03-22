using System;
namespace ticker.project2.Models
{

    public class Branding
    {
        public string logo_url { get; set; }
        public string icon_url { get; set; }
    }

    public class StockDetailData
    {
        public string ticker { get; set; }
        public string name { get; set; }
        public string market { get; set; }
        public string locale { get; set; }
        public string primary_exchange { get; set; }
        public string type { get; set; }
        public bool active { get; set; }
        public string currency_name { get; set; }
        public string cik { get; set; }
        public string composite_figi { get; set; }
        public string share_class_figi { get; set; }
        public double market_cap { get; set; }
        public string description { get; set; }
        public string ticker_root { get; set; }
        public string homepage_url { get; set; }
        public int total_employees { get; set; }
        public string list_date { get; set; }
        public Branding branding { get; set; }
        public int share_class_shares_outstanding { get; set; }
        public int weighted_shares_outstanding { get; set; }
    }

    public class DetailResult
    {
        public StockDetailData results { get; set; }
        public string status { get; set; }
        public string request_id { get; set; }
    }
}
