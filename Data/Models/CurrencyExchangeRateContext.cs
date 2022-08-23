using API.Data.Collector.Data.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Collector.Models
{
    public class CurrencyExchangeRateContext : DbContext
    {

        public CurrencyExchangeRateContext(DbContextOptions<CurrencyExchangeRateContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency_exchange_rate>().HasKey(x => new { x.Id });
        }

        public DbSet<Currency_exchange_rate> Currency_exchange_rate { get; set; } = null;

    }
}
