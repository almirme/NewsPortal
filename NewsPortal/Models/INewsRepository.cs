using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsPortal.Models
{
    public interface INewsRepository
    {
        IEnumerable<NewsArticle> GetLatest(int numberOfLatestNews);
    }
}