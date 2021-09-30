using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorStocks.Models;

namespace RazorStocks.Data
{
    public class StocksContext : DbContext
    {
        public StocksContext (DbContextOptions<StocksContext> options)
            : base(options)
        {
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Holding> Holdings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().ToTable("Stock");
            modelBuilder.Entity<Holding>().ToTable("Holding");
        }
    }
}
