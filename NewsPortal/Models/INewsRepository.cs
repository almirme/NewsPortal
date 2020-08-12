﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsPortal.Models
{
    public interface INewsRepository
    {
        NewsArticle GetById(int id);

        IEnumerable<NewsArticle> GetLatest(int numberOfLatestNews);

        IEnumerable<NewsArticle> GetAllForUser(string username);

        void AddNew(NewsArticle newsArticle);

        void Update(NewsArticle newsArticle);
    }
}