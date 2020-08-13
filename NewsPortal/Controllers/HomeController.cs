using NewsPortal.Common;
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
                NewsCategories = _repository.GetNewsCategories().ToList(),
                ListCriteria = $"{_uiMessages.SearchResultFor}: {searchViewModel.SearchTerm}",
            };

            return View(ViewName.Home_NewsList, newsListView);
        }

        public ActionResult NewsInCategory(byte Id)
        {
            string category = _repository.GetNewsCategories().SingleOrDefault(x => x.Id == Id).Name;

            List<NewsArticle> allNewsInCategory = _repository.GetLatest(0, category).ToList();

            NewsListViewModel newsListView = new NewsListViewModel
            {
                NewsArticles = allNewsInCategory,
                NewsCategories = _repository.GetNewsCategories().ToList(),
                ListCriteria = $"{_uiMessages.SearchResultFor}: {category}",
            };

            return View(ViewName.Home_NewsList, newsListView);
        }
    }
}