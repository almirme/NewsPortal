using NewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsPortal.Controllers
{
    [Authorize]
    public class NewsAdminController : Controller
    {
        INewsRepository _repository;
        private readonly string SingleNewsView = "NewsForm";
        private readonly string AllNewsForUserView = "AllUserNews";
        private readonly string ControllerName = "NewsAdmin";

        public NewsAdminController(INewsRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            IEnumerable<NewsArticle> all = _repository.GetAllForUser(User.Identity.Name);
            return View(AllNewsForUserView, all);
        }

        public ActionResult New()
        {
            NewsArticle test = new NewsArticle();

            return View(SingleNewsView, test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(NewsArticle newsArticle)
        {
            if (!ModelState.IsValid)
            {
                return View(SingleNewsView, newsArticle);
            }

            if (newsArticle.Id == 0)
            {
                newsArticle.Author = User.Identity.Name;
                newsArticle.PublishDate = DateTime.Now;

                _repository.AddNew(newsArticle);
            }
            else
            {
                _repository.Update(newsArticle);
            }

            return RedirectToAction("Index", this.ControllerName);
        }

        public ActionResult Search(SearchViewModel searchViewModel)
        {
            return View();
        }
    }
}