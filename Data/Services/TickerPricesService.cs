using System;
using System.Security.Cryptography;
using API.Data.Collector.Data.ViewModels;
using API.Data.Collector.Models;

namespace API.Data.Collector.Data.Services
{
    public class TickerPricesService
    {

        private TickerPricesContext _TickerContext;

        public TickerPricesService(TickerPricesContext context)
        {

            _TickerContext = context;

        }

        public void AddItem(Ticker_pricesVM item)
        {

            Ticker_prices _item = new Ticker_prices()
            {
                sub_id = ((int) item.sub_id+1),
                date = item.date,
                open = item.open,
                high = item.high,
                low = item.low,
                close = item.close,
                volume = item.volume
            };

            _TickerContext.Ticker_prices.Add(_item);
            _TickerContext.SaveChanges();

        }

        public List<Ticker_prices> GetAllItems()
        {
            return _TickerContext.Ticker_prices.OrderBy(d => d.sub_id).ThenBy(d => d.date).ToList();
        }

        public List<Ticker_prices> GetItemById(int ItemSubId)
        {

            return _TickerContext.Ticker_prices.Where(n => n.sub_id == ItemSubId).OrderBy(d => d.date).ToList();
        }


        public Ticker_prices GetItemByIdAndDate(int ItemSubId, string itemDate)
        {

            return _TickerContext.Ticker_prices.FirstOrDefault(n => n.sub_id == ItemSubId && n.date == itemDate);
        }

        public Ticker_prices UpdateItemById(int itemId, Ticker_pricesVM item)
        {
            var _item = _TickerContext.Ticker_prices.FirstOrDefault(n => n.sub_id == itemId && n.date == item.date);

            if (_item != null)
            {

                _item.sub_id = itemId;
                _item.open = item.open;
                _item.high = item.high;
                _item.low = item.low;
                _item.close = item.close;
                _item.volume = item.volume;

                _TickerContext.SaveChanges();

            }

            return _item;

        }

        public void DeleteItemById(int itemId, string date)
        {

            //var _item = _TickerContext.Ticker_prices.FirstOrDefault(n => n.sub_id == itemId && n.date == date);
            var items = _TickerContext.Ticker_prices.Where(n => n.sub_id == itemId && n.date == date).ToList();

            _TickerContext.Ticker_prices.RemoveRange(_TickerContext.Ticker_prices.Where(n => n.sub_id == itemId && n.date == date).ToList());
            _TickerContext.SaveChanges();
        
        }

        public void DeleteAllItems()
        {

            _TickerContext.Ticker_prices.RemoveRange(_TickerContext.Ticker_prices);
            _TickerContext.SaveChanges();
            /*
            _TickerContext.Ticker_prices.Delete();
            _TickerContext.SaveChanges();
            */
        }

    }
}
