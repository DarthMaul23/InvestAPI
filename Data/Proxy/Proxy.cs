using API.Data.Collector.Data.Models;
using API.Data.Collector.Data.ViewModels;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace API.Data.Collector.Data.Proxy
{
    public class CustomProxy
    {
        public CustomProxy()
        {

        }

        public List<Ticker_names> GetNames()
        {

            List<Ticker_names> names = new List<Ticker_names>();
            GetNamesRequest(names);

            return names;
        }

        private List<Ticker_names> GetNamesRequest(List<Ticker_names> names)
        {
            /*
            string url = "http://localhost:5026/api/TickerNames/get-all-items";
            var todo = url.GetJsonFromUrl().FromJson<Ticker_names>();
            todo.PrintDump();

            names = todo.ToList();
            */
            
            names.Add(new Ticker_names(){Id = 0, Type = 1, Name = "TSLA"});

            return names;
        }

    }
}