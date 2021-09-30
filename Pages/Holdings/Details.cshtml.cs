using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorStocks.Data;
using RazorStocks.Models;

namespace RazorStocks.Pages.Holdings
{
    public class DetailsModel : PageModel
    {
        private readonly RazorStocks.Data.StocksContext _context;

        public DetailsModel(RazorStocks.Data.StocksContext context)
        {
            _context = context;
        }

        public Holding Holding { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Holding = await _context.Holdings.FirstOrDefaultAsync(m => m.ID == id);

            if (Holding == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
