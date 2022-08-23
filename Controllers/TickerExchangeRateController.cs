using API.Data.Collector.Data.Services;
using API.Data.Collector.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Data.Collector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TickerExchangeRateController : ControllerBase
    {

        public CurrencyService _CurrencyService;

        public TickerExchangeRateController(CurrencyService namesService)
        {
            _CurrencyService = namesService;
        }

        [HttpGet("get-all-items")]
        public IActionResult GetAllItems()
        {
            var allItems = _CurrencyService.GetAllItems();

            return Ok(allItems);
        }

        [HttpGet("get-item-by-id/{id}")]
        public IActionResult GetItemById(int id)
        {
            var item = _CurrencyService.GetItemById(id);

            return Ok(item);
        }

        [HttpPost("add-item")]
        public IActionResult AddItem([FromBody] Currency_exchange_rateVM item)
        {
            _CurrencyService.AddItem(item);

            return Ok();
        }

        [HttpPut("update-item-by-id/{id}")]
        public IActionResult UpdateItemById(int id, [FromBody] Currency_exchange_rateVM item)
        {
            var updatedItem = _CurrencyService.UpdateItemById(id, item);

            return Ok(updatedItem);
        }

        [HttpDelete("delete-item-by-id/{id}")]
        public IActionResult DeleteItemById(int id)
        {
            _CurrencyService.DeleteItemById(id);

            return Ok();
        }
        
        [HttpDelete("delete-all-items")]
        public IActionResult DeleteAllItems(int id)
        {
            _CurrencyService.DeleteAllItems();

            return Ok();
        }

    }
}
