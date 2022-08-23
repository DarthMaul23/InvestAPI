using API.Data.Collector.Data.Services;
using API.Data.Collector.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Data.Collector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TickerNamesController : ControllerBase
    {

        public TickerNamesService _NamesService;

        public TickerNamesController(TickerNamesService namesService)
        {
            _NamesService = namesService;
        }

        [HttpGet("get-all-items")]
        public IActionResult GetAllItems()
        {
            var allItems = _NamesService.GetAllItems();

            return Ok(allItems);
        }

        [HttpGet("get-item-by-id/{id}")]
        public IActionResult GetItemById(int id)
        {
            var item = _NamesService.GetItemById(id);

            return Ok(item);
        }

        [HttpPost("add-item")]
        public IActionResult AddItem([FromBody] Ticker_namesVM item)
        {
            _NamesService.AddItem(item);

            return Ok();
        }

        [HttpPut("update-item-by-id/{id}")]
        public IActionResult UpdateItemById(int id, [FromBody] Ticker_namesVM item)
        {
            var updatedItem = _NamesService.UpdateItemById(id, item);

            return Ok(updatedItem);
        }

        [HttpDelete("delete-item-by-id/{id}")]
        public IActionResult DeleteItemById(int id)
        {
            _NamesService.DeleteItemById(id);

            return Ok();
        }

    }
}
