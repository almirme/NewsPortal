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

        public ViewResult IndexAdmin(SearchViewModel searchViewModel)
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

        public ViewResult NewNews()
        {
            NewsFormViewModel newsFormView = new NewsFormViewModel
            {
                NewsArticle = new NewsArticle(),
                NewsCategories = _repository.GetNewsCategories()
            };

            return View(ViewName.NewsAdmin_NewsForm, newsFormView);
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
                NewsFormViewModel newsFormView = new NewsFormViewModel
                {
                    NewsArticle = article,
                    NewsCategories = _repository.GetNewsCategories()
                };

                return View(ViewName.NewsAdmin_NewsForm, newsFormView);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(NewsArticle newsArticle)
        {
            if (!ModelState.IsValid)
            {
                NewsFormViewModel newsFormView = new NewsFormViewModel
                {
                    NewsArticle = newsArticle,
                    NewsCategories = _repository.GetNewsCategories()
                };

                return View(ViewName.NewsAdmin_NewsForm, newsFormView);
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