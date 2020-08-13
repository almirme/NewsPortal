using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsPortal.Models
{
    public class CommonViewModel
    {
        public IEnumerable<NewsArticle> NewsArticles { get; set; }
        public IEnumerable<NewsCategory> NewsCategories { get; set; }
    }
}