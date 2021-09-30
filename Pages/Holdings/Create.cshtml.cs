using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorStocks.Data;
using RazorStocks.Models;

namespace RazorStocks.Pages.Holdings
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
            IdsOfStocks = new List<int>{
                1,2,3
            };
            return Page();
        }

        [BindProperty]
        public Holding Holding { get; set; }
        [BindProperty]
        public List<int> IdsOfStocks {get;set;}

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Holdings.Add(Holding);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
