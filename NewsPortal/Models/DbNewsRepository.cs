using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsPortal.Models
{
    public class DbNewsRepository : INewsRepository, IDisposable
    {
        ApplicationDbContext _context;

        public DbNewsRepository()
        {
            _context = new ApplicationDbContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void AddNew(NewsArticle newsArticle)
        {
            _context.NewsArticles.Add(newsArticle);
            _context.SaveChanges();
        }

        public IEnumerable<NewsArticle> GetLatest(int numberOfLatestNews)
        {
            IEnumerable<NewsArticle> latestNews = _context.NewsArticles.OrderByDescending(d => d.PublishDate);
            int totalLatestNews = latestNews.Count();

            if (totalLatestNews < numberOfLatestNews)
            {
                numberOfLatestNews = totalLatestNews;
            }

            latestNews = latestNews.ToList().GetRange(0, numberOfLatestNews);

            return latestNews;
        }

        public void Update(NewsArticle newsArticle)
        {
            var newsArticleInDb = _context.NewsArticles.Single(c => c.Id == newsArticle.Id);
            newsArticleInDb.Title = newsArticle.Title;
            newsArticleInDb.Content = newsArticle.Content;
            newsArticleInDb.Category = newsArticle.Category;
            newsArticleInDb.PictureUrl = newsArticle.PictureUrl;

            _context.SaveChanges();
        }

        public NewsArticle GetById(int id)
        {
            return _context.NewsArticles.SingleOrDefault(n => n.Id == id);
        }

        public IEnumerable<NewsArticle> GetAllForUser(string username)
        {
            IEnumerable<NewsArticle> latestNews = from cust in _context.NewsArticles
                                                  where cust.Author == username
                                                  select cust;
            latestNews = latestNews.ToList();

            return latestNews;
        }
    }
}