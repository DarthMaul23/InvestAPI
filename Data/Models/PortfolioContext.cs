using API.Data.Collector.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace API.Data.Collector.Models
{
    public class PortfolioContext : DbContext
    {

        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Portfolio>().HasNoKey();
        }

        public DbSet<Portfolio> portfolio { get; set; }

        public List<Portfolio> GetOriginalPortfolioValue()
        {
            return portfolio.FromSqlRaw("EXECUTE [dbo].[GetOriginalProtfolioValue]").ToList();
        }

        public List<Portfolio> GetOriginalPortfolioItemsValue()
        {
            return portfolio.FromSqlRaw("EXECUTE [dbo].[GetOriginalProtfolioItemsValue]").ToList();
        }

        public List<Portfolio> GetCurrentPortfolioValue()
        {
            return portfolio.FromSqlRaw("EXECUTE [dbo].[GetCurrentProtfolioItemsValue]").ToList();
        }

        public List<Portfolio> GetItemHistoricalPortfolioValue(string name)
        {
            SqlParameter parameter = new SqlParameter("@name", name);
            return portfolio.FromSqlRaw("EXECUTE [dbo].[GetAllItemsHistoricalValues] @name", parameter).ToList();
        }

        public List<Portfolio> GetPortfolioValueOnDate(string date)
        {
            SqlParameter parameter = new SqlParameter("@date", date);
            return portfolio.FromSqlRaw("EXECUTE [dbo].[GetPortfolioValueOnDate] @date", parameter).ToList();
        }

    }
}
