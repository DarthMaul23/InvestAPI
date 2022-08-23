using YahooFinanceApi;

namespace API.Data.Collector.Data.Models
{
    public class Ticker
    {
        // required base properties
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }

        public Ticker(){
            
        }

        public void SetUp(string name, DateTime date, decimal open, decimal high, decimal low, decimal close, decimal volume)
        {

            this.Name = name;
            this.Date = date;
            this.Open = open;
            this.High = high;
            this.Low = low;
            this.Close = close;
            this.Volume = volume;

        }

    }

}