using API.Data.Collector.Data.Services;
using API.Data.Collector.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Data.Collector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TickerPurchaseController : ControllerBase
    {

        public TickerPurchaseService _PurchaseService;

        public TickerPurchaseController(TickerPurchaseService purchaseService)
        {
            _PurchaseService = purchaseService;
        }

        [HttpGet("get-all-items")]
        public IActionResult GetAllItems()
        {
            var allItems = _PurchaseService.GetAllItems();

            return Ok(allItems);
        }

        [HttpGet("get-item-by-id/{id}")]
        public IActionResult GetItemById(int id)
        {
            var item = _PurchaseService.GetItemById(id);

            return Ok(item);
        }

        [HttpPost("add-item")]
        public IActionResult AddItem([FromBody] Ticker_purchase_dateVM item)
        {
            _PurchaseService.AddItem(item);

            return Ok();
        }

        [HttpPut("update-item-by-id/{id}")]
        public IActionResult UpdateItemById(int id, [FromBody] Ticker_purchase_dateVM item)
        {
            var updatedItem = _PurchaseService.UpdateItemById(id, item);

            return Ok(updatedItem);
        }

        [HttpDelete("delete-item-by-id/{id}")]
        public IActionResult DeleteItemById(int id)
        {
            _PurchaseService.DeleteItemById(id);

            return Ok();
        }

    }
}
