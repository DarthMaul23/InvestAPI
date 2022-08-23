using API.Data.Collector.Data.Collectors;
using API.Data.Collector.Data.ViewModels;

namespace API.Data.Collector.Data.Services
{

    public class MarketNewsService
    {

        NewsCollector collector = new NewsCollector();

        public List<News_item> GetAllArticles()
        {

            return collector.GetListOfNews();
        }

        public News_item GetArticle(int id)
        {

            return collector.GetNewsItem(id);
        }
    }
}
