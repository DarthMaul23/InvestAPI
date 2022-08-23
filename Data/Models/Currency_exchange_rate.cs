namespace API.Data.Collector.Data.ViewModels
{
    public class Currency_exchange_rate
    {
        public int Id { get; set; }
        public string? Date { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public double Rate { get; set; }

    }
}
