using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorStocks.Data;
using RazorStocks.Models;

namespace RazorStocks.Pages.Stocks
{
    public class CreateModel : PageModel
    {
        private readonly RazorStocks.Data.StocksContext _context;

        public CreateModel(RazorStocks.Data.StocksContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Stock Stock { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyStock = new Stock();

            if (await TryUpdateModelAsync<Stock>(
                emptyStock,
                "stock",   // Prefix for form value.
                s => s.Symbol, s => s.Industry ))
            {
                _context.Stocks.Add(Stock);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
