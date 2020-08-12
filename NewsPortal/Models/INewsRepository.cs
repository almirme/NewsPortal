using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsPortal.Models
{
    public interface INewsRepository
    {
        NewsArticle GetById(int id);

        IEnumerable<NewsArticle> GetLatest(int numberOfLatestNews, string category = "");

        IEnumerable<NewsArticle> GetAllForUser(string username);

        IEnumerable<NewsArticle> GetAllThatContain(string searchTerm, string author = "");

        void AddNew(NewsArticle newsArticle);

        void Update(NewsArticle newsArticle);

        IEnumerable<NewsCategory> GetNewsCategories();
    }
}