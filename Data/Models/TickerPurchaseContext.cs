using API.Data.Collector.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Collector.Models
{
    public class TickerPurchaseContext : DbContext
    {

        public TickerPurchaseContext(DbContextOptions<TickerPurchaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticker_purchase_date>().HasKey(x => new { x.sub_id });
        }

        public DbSet<Ticker_purchase_date> Ticker_purchase_date { get; set; } = null;

    }
}
