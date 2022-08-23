using System.Security.Cryptography;
using System.ComponentModel;
using System.Collections;
using System;
using System.Text.Json;
using API.Data.Collector.Data.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Aletheia.Service;
using Aletheia.Service.StockData;
using API.Data.Collector.Data.ViewModels;

namespace API.Data.Collector.Data.Services
{
    public class StockService
    {

        private AletheiaService service = new AletheiaService("7435D6E4272F4CBD9B99161339EC4A67");

        private StaticData data = new StaticData();

        private List<string> names = new List<string>();

        private static List<Ticker> stocks = new List<Ticker>();

        public int NoOfItems()
        {

            return stocks.Count;
        }

        public void LoadAllItems()
        {

            stocks.Clear();
            foreach (var name in data.GetNames())
            {
                Console.WriteLine("Loading " + name.Name);
                AddElement(name);

            }

        }

        private async void AddElement(Ticker_names ticker)
        {
            if(ticker.Type==1){
                StockData quote = service.GetStockDataAsync(ticker.Name, true, true).Result;
                Ticker ticker1 = new Ticker();
                ticker1.SetUp(ticker.Name.Trim(), DateTime.Now, Convert.ToDecimal(quote.SummaryData.Open), Convert.ToDecimal(quote.SummaryData.DayRangeHigh), Convert.ToDecimal(quote.SummaryData.DayRangeLow), Convert.ToDecimal(quote.SummaryData.Price), Convert.ToDecimal(quote.SummaryData.Volume));
                stocks.Add(ticker1);
            }
        }

        public JArray GetAllItems()
        {
            LoadAllItems();

            return JArray.Parse(JsonConvert.SerializeObject(stocks));
        }

        public JArray GetItemByName(string name)
        {

            return JArray.Parse(JsonConvert.SerializeObject(stocks.Where(n => n.Name.Contains(name))));
        }
    }
}