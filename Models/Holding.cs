using System;
using System.Collections.Generic;

namespace RazorStocks.Models
{
    public class Holding
    {
        public int ID { get; set; }
        public int StockID { get; set; }

        public decimal Cost {get;set;}
        public decimal NoOfShares {get;set;}
        public DateTime PurchaseDate { get; set; }
    }
}