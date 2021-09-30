using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorStocks.Data;
using RazorStocks.Models;

namespace RazorStocks.Pages.Holdings
{
    public class EditModel : PageModel
    {
        private readonly RazorStocks.Data.StocksContext _context;

        public EditModel(RazorStocks.Data.StocksContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Holding).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoldingExists(Holding.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HoldingExists(int id)
        {
            return _context.Holdings.Any(e => e.ID == id);
        }
    }
}
