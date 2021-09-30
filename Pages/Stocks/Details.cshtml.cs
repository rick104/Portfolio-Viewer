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
    public class DetailsModel : PageModel
    {
        private readonly RazorStocks.Data.StocksContext _context;

        public DetailsModel(RazorStocks.Data.StocksContext context)
        {
            _context = context;
        }

        public Stock Stock { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stock = await _context.Stocks
            .Include(h => h.Holdings)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

            if (Stock == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
