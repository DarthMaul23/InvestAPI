using API.Data.Collector.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Data.Collector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketNewsController : Controller
    {

        public MarketNewsService _NewsService;

        public MarketNewsController(MarketNewsService context)
        {

            _NewsService = context;

        }

        [HttpGet("get-all-items/")]
        public IActionResult GetAllMarketNews()
        {

            var allArticles = _NewsService.GetAllArticles();

            return Ok(allArticles);
        }

        [HttpGet("get-item-by-id/{id}")]
        public IActionResult GetAllMarketNewsArticle(int id)
        {

            var articles = _NewsService.GetArticle(id);

            return Ok(articles);
        }

    }
}
