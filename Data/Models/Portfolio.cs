namespace API.Data.Collector.Data.ViewModels
{
    public class Portfolio
    {

        public string Name { get; set; }
        public string? Date { get; set; }
        public decimal? High { get; set; }
        public decimal? Volume { get; set; }
        public decimal? Value_USD { get; set; }
        public decimal? PortfolioValue { get; set; }
        public decimal? shareOfPortfolio { get; set; }
        public decimal? profitUSD { get; set; }
        public decimal? profitPercent { get; set; }

    }
}
