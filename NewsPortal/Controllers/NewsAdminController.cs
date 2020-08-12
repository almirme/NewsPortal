using NewsPortal.Common;
using NewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NewsPortal.Controllers
{
    [Authorize]
    public class NewsAdminController : Controller
    {
        INewsRepository _repository;

        public NewsAdminController(INewsRepository repository)
        {
            _repository = repository;
        }

        public ActionResult IndexAdmin(SearchViewModel searchViewModel)
        {
            IEnumerable<NewsArticle> newsOfAuthor;
            if (String.IsNullOrWhiteSpace(searchViewModel.SearchTerm))
            {
                newsOfAuthor = _repository.GetAllForUser(User.Identity.Name);
            }
            else
            {
                newsOfAuthor = _repository.GetAllThatContain(searchViewModel.SearchTerm, User.Identity.Name);
            }

            return View(ViewName.NewsAdmin_Index, newsOfAuthor);
        }

        public ActionResult NewNews()
        {
            return View(ViewName.NewsAdmin_NewsForm, new NewsArticle());
        }

        public ActionResult EditNews(int id)
        {
            NewsArticle article = _repository.GetById(id);

            if (article == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(ViewName.NewsAdmin_NewsForm, article);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(NewsArticle newsArticle)
        {
            if (!ModelState.IsValid)
            {
                return View(ViewName.NewsAdmin_NewsForm, newsArticle);
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

            return RedirectToAction(ViewName.NewsAdmin_Index, ControllerName.NewsAdmin);
        }
    }
}