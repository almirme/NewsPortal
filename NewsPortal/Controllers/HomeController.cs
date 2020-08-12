using NewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsPortal.Controllers
{
    public class HomeController : Controller
    {
        INewsRepository _repository;
        IUIMessages _uiMessages = UIMessages.GetMessagesForLanguage();

        public HomeController(INewsRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index()
        {
            return View(_repository);
        }

        public ActionResult SingleNews(int id)
        {
            NewsArticle article = _repository.GetById(id);

            return View(article);
        }

        public ActionResult NewsList(SearchViewModel searchViewModel)
        {
            List<NewsArticle> articles = _repository.GetAllThatContain(searchViewModel.SearchTerm).ToList();

            NewsListViewModel newsListView = new NewsListViewModel
            {
                NewsArticles = articles,
                ListCriteria = $"{_uiMessages.SearchResultFor}: {searchViewModel.SearchTerm}",
            };

            return View(newsListView);
        }
    }
}