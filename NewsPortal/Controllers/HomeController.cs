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

        public ActionResult Search(SearchViewModel searchViewModel)
        {
            return View(_repository);
        }

        public ActionResult NewsList()
        {
            return View(_repository);
        }
    }
}