namespace API.Data.Collector.Data.ViewModels
{
    public class PortfolioVM
    {

        public string Name { get; set; }
        public string? Date { get; set; }
        public double? High { get; set; }
        public double? Volume { get; set; }
        public double? Value_USD { get; set; }
        public decimal? PortfolioValue { get; set; }
        public decimal? shareOfPortfolio { get; set; }
        public decimal? profitUSD { get; set; }
        public decimal? profitPercent { get; set; }

    }
}
