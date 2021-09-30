using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorStocks.Data;
using RazorStocks.Models;

namespace RazorStocks.Pages.Stocks
{
    public class IndexModel : PageModel
    {
        private readonly RazorStocks.Data.StocksContext _context;

        public IndexModel(RazorStocks.Data.StocksContext context)
        {
            _context = context;
        }
        public string SymbolSort { get; set; }
        public string TotalValueSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Stock> Stocks { get;set; }

        public async Task OnGetAsync(string sortOrder)
        {
            // using System;

            SymbolSort = String.IsNullOrEmpty(sortOrder) ? "symbol_desc" : "symbol";
            TotalValueSort = sortOrder == "	TotalValue" ? "totalvalue_desc" : "TotalValue";

            IQueryable<Stock> stocksIQ = from s in _context.Stocks
                                            select s;

            switch (sortOrder)
            {
                case "symbol":
                    stocksIQ = stocksIQ.OrderBy(s => s.Symbol);
                    break;
                case "symbol_desc":
                    stocksIQ = stocksIQ.OrderByDescending(s => s.Symbol);
                    break;
                case "totalvalue_desc":
                    stocksIQ = stocksIQ.OrderByDescending(s => s.TotalValue);
                    break;
                case "totalvalue":
                    stocksIQ = stocksIQ.OrderBy(s => s.TotalValue);
                    break;
                default:
                    stocksIQ = stocksIQ.OrderBy(s => s.TotalValue);
                    break;
            }
            Stocks = await stocksIQ.AsNoTracking().ToListAsync();
        }
    }
}
