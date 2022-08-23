using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Collector.Data.ViewModels
{
    [Keyless]
    public class Ticker_pricesVM
    {
        public int sub_id { get; set; }
        public string date { get; set; }
        public decimal? open { get; set; }
        public decimal? high { get; set; }
        public decimal? low { get; set; }
        public decimal? close { get; set; }
        public decimal? volume { get; set; }
    }
}
