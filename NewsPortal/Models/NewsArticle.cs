using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsPortal.Models
{
    public class NewsArticle
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime PublishDate { get; set; }

        public string Content { get; set; }

        public string PictureUrl { get; set; }

        public string Category { get; set; }
    }
}