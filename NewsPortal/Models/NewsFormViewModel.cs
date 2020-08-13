using Microsoft.Owin.Security.DataHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsPortal.Models
{
    public class NewsFormViewModel
    {
        public NewsArticle NewsArticle { get; set; }

        public IEnumerable<NewsCategory> NewsCategories { get; set; }
    }
}