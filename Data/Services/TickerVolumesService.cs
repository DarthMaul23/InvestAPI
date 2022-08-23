using API.Data.Collector.Data.ViewModels;
using API.Data.Collector.Models;

namespace API.Data.Collector.Data.Services
{
    public class TickerVolumesService
    {

        private TickerVolumesContext _TickerContext;

        public TickerVolumesService(TickerVolumesContext context)
        {

            _TickerContext = context;

        }

        public void AddItem(Ticker_volumesVM item)
        {

            var _item = new Ticker_volumes()
            {
                id = ((int) _TickerContext.Ticker_volumes.ToList().Count())+1,
                volume = item.volume
            };

            _TickerContext.Ticker_volumes.Add(_item);
            _TickerContext.SaveChanges();

        }

        public List<Ticker_volumes> GetAllItems()
        {
            return _TickerContext.Ticker_volumes.ToList();
        }

        public Ticker_volumes GetItemById(int? itemId)
        {
            return _TickerContext.Ticker_volumes.FirstOrDefault(n => n.id == itemId);
        }

        public Ticker_volumes UpdateItemById(int itemId, Ticker_volumesVM item)
        {
            var _item = _TickerContext.Ticker_volumes.FirstOrDefault(n => n.id == itemId);

            if (_item != null)
            {

                _item.volume = item.volume;

                _TickerContext.SaveChanges();

            }

            return _item;

        }

        public void DeleteItemById(int itemId)
        {

            var _item = _TickerContext.Ticker_volumes.FirstOrDefault(n => n.id == itemId);

            if (_item != null)
            {

                _TickerContext.Ticker_volumes.Remove(_item);
                _TickerContext.SaveChanges();

            }

        }

        public void DeleteAllItems()
        {

            _TickerContext.Ticker_volumes.RemoveRange(_TickerContext.Ticker_volumes);
            _TickerContext.SaveChanges();

        }

    }
}
