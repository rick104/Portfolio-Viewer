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
    public class IndexModel : PageModel
    {
        private readonly RazorStocks.Data.StocksContext _context;

        public IndexModel(RazorStocks.Data.StocksContext context)
        {
            _context = context;
        }

        public IList<Holding> Holding { get;set; }

        public async Task OnGetAsync()
        {
            Holding = await _context.Holdings.ToListAsync();
        }
    }
}
