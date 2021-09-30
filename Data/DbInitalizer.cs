using RazorStocks.Models;
using System;
using System.Linq;

namespace RazorStocks.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StocksContext context)
        {
            // Look for any students.
            if (context.Stocks.Any())
            {
                return;   // DB has been seeded
            }

            var stocks = new Stock[]
            {
                new Stock{Symbol = "SKLZ" }
            };

            context.Stocks.AddRange(stocks);
            context.SaveChanges();

            var holdings = new Holding[]
            {
                new Holding{StockID=1, Cost= 12.05M, NoOfShares = 33.195851M, PurchaseDate =DateTime.Parse("2021-11-08") },
            };

            context.Holdings.AddRange(holdings);
            context.SaveChanges();
        }
    }
}