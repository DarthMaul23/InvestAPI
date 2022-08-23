using API.Data.Collector.Data.ViewModels;
using API.Data.Collector.Models;

namespace API.Data.Collector.Data.Services
{
    public class CurrencyService
    {

        private CurrencyExchangeRateContext _TickerContext;

        public CurrencyService(CurrencyExchangeRateContext context)
        {

            _TickerContext = context;

        }

        public void AddItem(Currency_exchange_rateVM item)
        {

            var _item = new Currency_exchange_rate()
            {
                Id = ((int) _TickerContext.Currency_exchange_rate.ToList().Count())+1,
                From = item.From,
                To = item.To,
                Rate = item.Rate
            };

            _TickerContext.Currency_exchange_rate.Add(_item);
            _TickerContext.SaveChanges();

        }

        public List<Currency_exchange_rate> GetAllItems()
        {
            return _TickerContext.Currency_exchange_rate.ToList();
        }

        public Currency_exchange_rate GetItemById(int? itemId)
        {
            return _TickerContext.Currency_exchange_rate.FirstOrDefault(n => n.Id == itemId);
        }

        public Currency_exchange_rate UpdateItemById(int itemId, Currency_exchange_rateVM item)
        {
            var _item = _TickerContext.Currency_exchange_rate.FirstOrDefault(n => n.Id == itemId);

            if (_item != null)
            {

                _item.From = item.From;
                _item.To = item.To;
                _item.Rate = item.Rate;

                _TickerContext.SaveChanges();

            }

            return _item;

        }

        public void DeleteItemById(int itemId)
        {

            var _item = _TickerContext.Currency_exchange_rate.FirstOrDefault(n => n.Id == itemId);

            if (_item != null)
            {

                _TickerContext.Currency_exchange_rate.Remove(_item);
                _TickerContext.SaveChanges();

            }

        }

        public void DeleteAllItems()
        {

            _TickerContext.Currency_exchange_rate.RemoveRange(_TickerContext.Currency_exchange_rate);
            _TickerContext.SaveChanges();

        }

    }
}
