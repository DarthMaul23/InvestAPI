using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Data.Collector.Data.ViewModels
{
    [Keyless]
    public class Ticker_purchase_dateVM
    {
        public int sub_id { get; set; }
        public string? purchase_date { get; set; }

    }
}
