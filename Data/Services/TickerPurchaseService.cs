using API.Data.Collector.Data.ViewModels;
using API.Data.Collector.Data.Models;
using API.Data.Collector.Models;
using System.Linq;

namespace API.Data.Collector.Data.Services
{
    public class TickerPurchaseService
    {

        private TickerPurchaseContext _TickerContext;

        private StaticData data = new StaticData();

        public TickerPurchaseService(TickerPurchaseContext context)
        {

            _TickerContext = context;

        }

        public void AddItem(Ticker_purchase_dateVM item)
        {

            var _item = new Ticker_purchase_date()
            {
                sub_id = ((int) _TickerContext.Ticker_purchase_date.ToList().Count())+1,
                purchase_date = item.purchase_date
            };
            
            _TickerContext.Ticker_purchase_date.Add(_item);
            _TickerContext.SaveChanges();

        }

        public List<Ticker_purchase_date> GetAllItems()
        {
            
            return _TickerContext.Ticker_purchase_date.OrderBy(n => n.sub_id).ToList();
        }

        public Ticker_purchase_date GetItemById(int? itemId)
        {
            return _TickerContext.Ticker_purchase_date.FirstOrDefault(n => n.sub_id == itemId);
        }

        public Ticker_purchase_date UpdateItemById(int itemId, Ticker_purchase_dateVM item)
        {
            var _item = _TickerContext.Ticker_purchase_date.FirstOrDefault(n => n.sub_id == itemId);

            if (_item != null)
            {

                _item.sub_id = item.sub_id;
                _item.purchase_date = item.purchase_date;
                
                _TickerContext.SaveChanges();

            }

            return _item;

        }

        public void DeleteItemById(int itemId)
        {

            var _item = _TickerContext.Ticker_purchase_date.FirstOrDefault(n => n.sub_id == itemId);

            if (_item != null)
            {

                _TickerContext.Ticker_purchase_date.Remove(_item);
                _TickerContext.SaveChanges();

            }

        }

    }
}
