﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsPortal.Models
{
    public class NewsListViewModel
    {
        public List<NewsArticle> NewsArticles { get; set; }

        public string SearchTerm { get; set; }
    }
}