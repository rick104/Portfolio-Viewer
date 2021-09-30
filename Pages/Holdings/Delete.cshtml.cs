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
    public class DeleteModel : PageModel
    {
        private readonly RazorStocks.Data.StocksContext _context;

        public DeleteModel(RazorStocks.Data.StocksContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Holding = await _context.Holdings.FindAsync(id);

            if (Holding != null)
            {
                _context.Holdings.Remove(Holding);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
