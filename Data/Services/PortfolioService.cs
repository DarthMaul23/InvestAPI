using API.Data.Collector.Data.ViewModels;
using API.Data.Collector.Models;
using System.Data.SqlClient;

namespace API.Data.Collector.Data.Services
{
    public class PortfolioService
    {

        private PortfolioContext _portfolioContext;

        public PortfolioService(PortfolioContext context)
        {

            _portfolioContext = context;

        }

        public List<Portfolio> GetOriginalPortfolioValue()
        {   

            return _portfolioContext.GetOriginalPortfolioValue();
        }

        public List<Portfolio> GetOriginalPortfolioItemsValue()
        {   

            return _portfolioContext.GetOriginalPortfolioItemsValue();
        }

        public List<Portfolio> GetCurrentPortfolioValue()
        {   

            return _portfolioContext.GetCurrentPortfolioValue();
        }

        public List<Portfolio> GetHistoricalPortfolioItemValue(string? name)
        {   

            return _portfolioContext.GetItemHistoricalPortfolioValue(name);
        }

        public List<Portfolio> GetPortfolioValueOnDate(string date)
        {   

            return _portfolioContext.GetPortfolioValueOnDate(date);
        }
    }
}
