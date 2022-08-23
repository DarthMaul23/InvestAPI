using API.Data.Collector.Data.ViewModels;
using API.Data.Collector.Data.Models;
using API.Data.Collector.Models;
using System.Linq;

namespace API.Data.Collector.Data.Services
{
    public class TickerNamesService
    {

        private TickerNamesContext _TickerContext;

        private StaticData data = new StaticData();

        public TickerNamesService(TickerNamesContext context)
        {

            _TickerContext = context;

        }

        public void AddItem(Ticker_namesVM item)
        {

            var _item = new Ticker_names()
            {
                Id = ((int) _TickerContext.Ticker_names.ToList().Count())+1,
                Type = item.Type,
                Name = item.Name

            };

            Console.WriteLine("Item: "+_item.Id);
            
            _TickerContext.Ticker_names.Add(_item);
            _TickerContext.SaveChanges();

        }

        public List<Ticker_names> GetAllItems()
        {
            
            var list = _TickerContext.Ticker_names.OrderBy(n => n.Id).ToList();
            
            foreach(var item in list){

                data.AddElement(item);

            }

            return _TickerContext.Ticker_names.OrderBy(n => n.Id).ToList();
        }

        public Ticker_names GetItemById(int? itemId)
        {
            return _TickerContext.Ticker_names.FirstOrDefault(n => n.Id == itemId);
        }

        public Ticker_names UpdateItemById(int itemId, Ticker_namesVM item)
        {
            var _item = _TickerContext.Ticker_names.FirstOrDefault(n => n.Id == itemId);

            if (_item != null)
            {

                _item.Name = item.Name;
                _item.Type = item.Type;
                
                _TickerContext.SaveChanges();

            }

            return _item;

        }

        public void DeleteItemById(int itemId)
        {

            var _item = _TickerContext.Ticker_names.FirstOrDefault(n => n.Id == itemId);

            if (_item != null)
            {

                _TickerContext.Ticker_names.Remove(_item);
                _TickerContext.SaveChanges();

            }

        }

    }
}
