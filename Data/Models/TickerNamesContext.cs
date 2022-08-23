using API.Data.Collector.Data.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Collector.Models
{
    public class TickerNamesContext : DbContext
    {

        public TickerNamesContext(DbContextOptions<TickerNamesContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticker_names>().HasKey(x => new { x.Id });
        }

        public DbSet<Ticker_names> Ticker_names { get; set; } = null;

    }
}
