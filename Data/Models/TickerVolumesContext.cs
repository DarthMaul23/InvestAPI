using API.Data.Collector.Data.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Collector.Models
{
    public class TickerVolumesContext : DbContext
    {

        public TickerVolumesContext(DbContextOptions<TickerVolumesContext> options) : base(options)
        {

        }

        public DbSet<Ticker_volumes> Ticker_volumes { get; set; } = null;

    }
}
