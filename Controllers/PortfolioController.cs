using API.Data.Collector.Data.Services;
using API.Data.Collector.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Data.Collector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {

        public PortfolioService _portfolioService;

        public PortfolioController(PortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet("get-original-portfolio-value")]
        public IActionResult GetOriginalPortfolioValue()
        {
            return Ok(_portfolioService.GetOriginalPortfolioValue());
        }

        [HttpGet("get-original-portfolio-items-value")]
        public IActionResult GetOriginalPortfolioItemsValue()
        {
            return Ok(_portfolioService.GetOriginalPortfolioItemsValue());
        }

        [HttpGet("get-current-portfolio-value")]
        public IActionResult GetCurrentPortfolioValue()
        {
            return Ok(_portfolioService.GetCurrentPortfolioValue());
        }

        [HttpGet("get-historical-portfolio-value")]
        public IActionResult GetHistoricalPortfolioValue(string? name)
        {
            if (name != null)
            {
                return Ok(_portfolioService.GetHistoricalPortfolioItemValue(name));
            }

            return Ok("Ticker NAME was not supplied!");
        }

        [HttpGet("get-portfolio-value-on-date")]
        public IActionResult GetPortfolioValueOnDate(string? date)
        {
            if (date != null)
            {
                return Ok(_portfolioService.GetPortfolioValueOnDate(date));
            }

            return Ok("parameter DATE was not supplied!");
        }

    }
}
