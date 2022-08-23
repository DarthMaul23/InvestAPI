using API.Data.Collector.Data.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Collector.Models
{
    public class TickerPricesContext : DbContext
    {

        public TickerPricesContext(DbContextOptions<TickerPricesContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticker_prices>().HasKey(x => new { x.sub_id, x.date });
            var decimalProps = modelBuilder.Model
            .GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => (System.Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType) == typeof(decimal));

            foreach (var property in decimalProps)
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }
        }

        public DbSet<Ticker_prices> Ticker_prices { get; set; } = null;

    }
}
