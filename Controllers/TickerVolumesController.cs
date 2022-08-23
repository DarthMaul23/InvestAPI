using API.Data.Collector.Data.Services;
using API.Data.Collector.Data.ViewModels;
using API.Data.Collector.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sentry;

namespace API.Data.Collector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TickerVolumesController : ControllerBase
    {

        public TickerVolumesService _VolumesService;
        private readonly IHub _sentryHub;

        public TickerVolumesController(TickerVolumesService itemsService, IHub sentryHub)
        {
            _VolumesService = itemsService;
            _sentryHub = sentryHub;
        }

        [HttpGet("get-all-items")]
        public IActionResult GetAllItems()
        {
            List<Ticker_volumes> allItems = null;

            var childSpan = _sentryHub.GetSpan()?.StartChild("additional-work");

            try
            {

                allItems = _VolumesService.GetAllItems();

                childSpan?.Finish(SpanStatus.Ok);

            }
            catch (Exception e)
            {
                new Tagging().SetTagg("ACTION_ERROR", "GetAllItems()", SentryLevel.Fatal);
                childSpan?.Finish(e);
            }

            return Ok(allItems);
        }

        [HttpGet("get-item-by-id/{id}")]
        public IActionResult GetItemById(int id)
        {

            Ticker_volumes item = null;

            var childSpan = _sentryHub.GetSpan()?.StartChild("additional-work");

            try
            {

                item = _VolumesService.GetItemById(id);

                childSpan?.Finish(SpanStatus.Ok);


            }
            catch (Exception e)
            {
                new Tagging().SetTagg("ACTION_ERROR", "GetItemById(" + id + ")", SentryLevel.Fatal);
                childSpan?.Finish(e);
            }

            return Ok(item);
        }

        [HttpPost("add-item")]
        public IActionResult AddItem([FromBody] Ticker_volumesVM item)
        {

            var childSpan = _sentryHub.GetSpan()?.StartChild("additional-work");

            try
            {

                _VolumesService.AddItem(item);
                childSpan?.Finish(SpanStatus.Ok);

            }
            catch (Exception e)
            {

                new Tagging().SetTagg("ACTION_ERROR", "AddItem(" + item + ")", SentryLevel.Fatal);

            }


            return Ok();
        }

        [HttpPut("update-item-by-id/{id}")]
        public IActionResult UpdateItemById(int id, [FromBody] Ticker_volumesVM item)
        {

            Ticker_volumes updatedItem;
            var childSpan = _sentryHub.GetSpan()?.StartChild("additional-work");

            try
            {

                updatedItem = _VolumesService.UpdateItemById(id, item);
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

                _VolumesService.DeleteAllItems();
                childSpan?.Finish(SpanStatus.Ok);

            }
            catch (Exception e)
            {

                new Tagging().SetTagg("ACTION_ERROR", "DeleteAllItems()", SentryLevel.Fatal);

            }

            return Ok();
        }

        [HttpDelete("delete-item-by-id/{id}")]
        public IActionResult DeleteItemById(int id)
        {

            var childSpan = _sentryHub.GetSpan()?.StartChild("additional-work");

            try
            {

                _VolumesService.DeleteItemById(id);
                childSpan?.Finish(SpanStatus.Ok);

            }
            catch (Exception e)
            {

                new Tagging().SetTagg("ACTION_ERROR", "DeleteItemById(" + id + ")", SentryLevel.Fatal);

            }

            return Ok();
        }

    }
}
