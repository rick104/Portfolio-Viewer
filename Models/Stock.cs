using System;
using System.Collections.Generic;

namespace RazorStocks.Models
{
    public class Stock
    {
        public int ID { get; set; }
        public string Symbol { get; set; }
        public string Industry { get; set; }
        public ICollection<Holding> Holdings { get; set; }
        public decimal CurrentPrice {get;set;}
        public double TotalValue {get;set;}
        public decimal TotalGain {get;set;}
        public decimal AverageCost {get;set;}
    }
}