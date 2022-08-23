using API.Data.Collector.Data.Services;
using API.Data.Collector.Data.Models;
using API.Data.Collector.Data.ViewModels;
using API.Data.Collector.Data.Proxy;

namespace API.Data.Collector.Data.Models
{
    public class StaticData
    {
        static List<Ticker_names> names = new List<Ticker_names>();

        public StaticData()
        {
            LoadData();
        }

        public List<Ticker_names> GetNames()
        {

            LoadData();

            return names;
        }

        public void AddElement(Ticker_names name)
        {
            names.Add(name);
        }

        private void LoadData()
        {
            CustomProxy proxy = new CustomProxy();
            names = proxy.GetNames();

        }

    }
}