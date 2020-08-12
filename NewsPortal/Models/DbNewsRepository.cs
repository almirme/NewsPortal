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

        public IEnumerable<NewsArticle> GetLatest(int numberOfLatestNews)
        {
            return _context.NewsArticles.OrderByDescending(d => d.PublishDate).ToList();
        }
    }
}