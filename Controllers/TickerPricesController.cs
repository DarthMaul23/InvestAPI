using System;
using API.Data.Collector.Data.Services;
using API.Data.Collector.Data.ViewModels;
using API.Data.Collector.Logging;
using Microsoft.AspNetCore.Mvc;
using Sentry;

namespace API.Data.Collector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TickerPricesController : ControllerBase
    {

        public TickerPricesService _PricesService;
        private readonly IHub _sentryHub;

        public TickerPricesController(TickerPricesService pricesService, IHub sentryHub)
        {
            _PricesService = pricesService;
            _sentryHub = sentryHub;
        }

        [HttpGet("get-all-items")]
        public IActionResult GetAllItems()
        {
            List<Ticker_prices> allItems = null;

            var childSpan = _sentryHub.GetSpan()?.StartChild("additional-work");

            try
            {

                allItems = _PricesService.GetAllItems();

                childSpan?.Finish(SpanStatus.Ok);

            }
            catch (Exception e)
            {
                new Tagging().SetTagg("ACTION_ERROR", "GetAllItems()", SentryLevel.Fatal);
                childSpan?.Finish(e);
            }

            return Ok(allItems);
        }

        [HttpGet("get-item-by-id/{sub_id}")]
        public IActionResult GetItemById(int sub_id)
        {

            List<Ticker_prices> items = null;

            var childSpan = _sentryHub.GetSpan()?.StartChild("additional-work");

            try
            {

                items = _PricesService.GetItemById(sub_id);

                childSpan?.Finish(SpanStatus.Ok);


            }
            catch (Exception e)
            {
                new Tagging().SetTagg("ACTION_ERROR", "GetItemById(sub_id: " + sub_id + ")", SentryLevel.Fatal);
                childSpan?.Finish(e);
            }

            return Ok(items);

        }

        [HttpGet("get-item-by-id-and-date/{sub_id}/{date}")]
        public IActionResult GetItemByIdAndDate(int sub_id, string date)
        {

            Ticker_prices item = null;

            var childSpan = _sentryHub.GetSpan()?.StartChild("additional-work");

            try
            {

                item = _PricesService.GetItemByIdAndDate(sub_id, date);

                childSpan?.Finish(SpanStatus.Ok);


            }
            catch (Exception e)
            {
                new Tagging().SetTagg("ACTION_ERROR", "GetItemByIdAndDate(sub_id: " + sub_id + " and date: " + date + " )", SentryLevel.Fatal);
                childSpan?.Finish(e);
            }

            return Ok(item);

        }

        [HttpPost("add-item")]
        public IActionResult AddItem([FromBody] Ticker_pricesVM item)
        {
           
            _PricesService.AddItem(item);

            return Ok();
        }

        [HttpPut("update-item-by-id/{id}/{date}")]
        public IActionResult UpdateItemById(int id, [FromBody] Ticker_pricesVM item)
        {

            Ticker_prices updatedItem;
            var childSpan = _sentryHub.GetSpan()?.StartChild("additional-work");

            try
            {

                updatedItem = _PricesService.UpdateItemById(id, item);
                childSpan?.Finish(SpanStatus.Ok);

            }
            catch (Exception e)
            {

                updatedItem = null;
                new Tagging().SetTagg("ACTION_ERROR", "UpdateItemById(" + id + ")", SentryLevel.Fatal);

            }

            return Ok(updatedItem);
        }

        [HttpDelete("delete-all-items")]
        public IActionResult DeleteAllItems()
        {

            var childSpan = _sentryHub.GetSpan()?.StartChild("additional-work");

            try
            {

                _PricesService.DeleteAllItems();
                childSpan?.Finish(SpanStatus.Ok);

            }
            catch (Exception e)
            {

                new Tagging().SetTagg("ACTION_ERROR", "DeleteAllItems()", SentryLevel.Fatal);

            }

            return Ok();
        }

        [HttpDelete("delete-item-by-id-and-date/{sub_id}/{date}")]
        public IActionResult DeleteItemById(int sub_id, string date)
        {

            var childSpan = _sentryHub.GetSpan()?.StartChild("additional-work");

            try
            {

                _PricesService.DeleteItemById(sub_id, date);
                childSpan?.Finish(SpanStatus.Ok);

            }
            catch (Exception e)
            {

                new Tagging().SetTagg("ACTION_ERROR", "DeleteItemById(" + sub_id + " and " + date + ")", SentryLevel.Fatal);

            }

            return Ok();
        }

    }
}
