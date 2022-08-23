using API.Data.Collector.Data.Services;
using API.Data.Collector.Data.ViewModels;
using API.Data.Collector.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace API.Data.Collector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TickersContoller : Controller
    {

        public StockService _StockService;

        public TickersContoller(StockService itemsService)
        {
            _StockService = itemsService;
        }

        [HttpGet("get-no-of-stocks")]
        public IActionResult GetNoOfItems(){

            return Ok(_StockService.NoOfItems());
        }

        [HttpGet("get-all-stocks")]
        public IActionResult GetAllItems()
        {

            return Content(_StockService.GetAllItems().ToString(), "application/json");//, Encoding.UTF8);
        }

        [HttpGet("get-stock-by-name/{name}")]
        public IActionResult GetItemByName(string name)
        {
            
            return Content(_StockService.GetItemByName(name).ToString(), "application/json");//, Encoding.UTF8);
        }

    }
}
