using API.Data.Collector.Data.ViewModels;
using HtmlAgilityPack;
using System.Net;
namespace API.Data.Collector.Data.Collectors
{
    public class NewsCollector
    {

        List<News_item> newsList = new List<News_item>();

        private string url = "https://edition.cnn.com";

        private HtmlWeb web = new HtmlWeb();

        public NewsCollector()
        {
            CollectNews();
        }

        public List<News_item> GetListOfNews()
        {
            return newsList;
        }

        public News_item GetNewsItem(int Id)
        {
            return newsList.ElementAt(Id);
        }

        private void AddNewItem(int id, string name, string link)
        {
            newsList.Add(new News_item() { Id = id, Name = name, Link = link });
        }

        private void CollectNews()
        {
            try
            {

                HtmlDocument html = web.Load(url + "/BUSINESS");

                HtmlNode news = html.DocumentNode.SelectSingleNode("//div[@class='column zn__column--idx-0']/ul");
                HtmlNodeCollection news1 = news.SelectNodes(".//li");

                foreach (HtmlNode item in news1)
                {

                    AddNewItem(news1.IndexOf(item), item.SelectSingleNode(".//a").SelectNodes("//span[@class='cd__headline-text vid-left-enabled']")[news1.IndexOf(item)].InnerText.Trim(), url + item.SelectSingleNode(".//a").Attributes["href"].Value);

                }

            }
            catch (WebException ex)
            {

                Console.WriteLine("Error adding new item: " + ex.Message);

            }

        }

    }

}
