using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsPortal;
using NewsPortal.Controllers;
using NewsPortal.Models;
using NewsPortal.Tests.Fakes;
using Unity.Injection;

namespace NewsPortal.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_OnRequest_ReturnsCorrectView()
        {
            HomeController controller = CreateTestHomeController();

            ViewResult result = controller.Index();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ViewName == "Index");
        }

        [TestMethod]
        public void Index_WhenDisplayed_HaveThreeLatestNewsForEachCategory()
        {
            FakeNewsRepository fakeNewsRepository = new FakeNewsRepository();
            HomeController controller = new HomeController(fakeNewsRepository);

            ViewResult result = controller.Index();
            var newsArticlesInView = ((CommonViewModel)result.Model).NewsArticles.ToList();

            List<int> expectedArticles = new List<int> { 2, 1, 0, 4, 5, 6, 3 };

            Assert.IsTrue(TestHelper.AreDataAsExpected<NewsArticle>(newsArticlesInView, 
                                                                    fakeNewsRepository.News,
                                                                    expectedArticles,
                                                                    TestHelper.NewsArticlesAreSame));
        }

        [TestMethod]
        public void Index_WhenDisplayed_HaveAllNewsCategories()
        {
            FakeNewsRepository fakeNewsRepository = new FakeNewsRepository();
            HomeController controller = new HomeController(fakeNewsRepository);

            ViewResult result = controller.Index();
            var newsCategoriesInView = ((CommonViewModel)result.Model).NewsCategories.ToList();

            List<int> expectedCategories = new List<int> { 0, 1, 2, 3, 4 };

            Assert.IsTrue(TestHelper.AreDataAsExpected<NewsCategory>(newsCategoriesInView,
                                                                     fakeNewsRepository.Categories,
                                                                     expectedCategories,
                                                                     TestHelper.NewsCategoriesAreSame));
        }

        [TestMethod]
        public void SingleNews_OnRequest_ReturnsCorrectView()
        {
            HomeController controller = CreateTestHomeController();

            ViewResult result = controller.SingleNews(1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ViewName == "SingleNews");
        }

        [TestMethod]
        public void SingleNews_OnRequest_HaveCorrectDataForNews()
        {
            FakeNewsRepository fakeNewsRepository = new FakeNewsRepository();
            HomeController controller = new HomeController(fakeNewsRepository);

            ViewResult result = controller.SingleNews(1);

            var newsOnPage = ((NewsArticle)result.Model);

            Assert.IsTrue(TestHelper.NewsArticlesAreSame(newsOnPage, fakeNewsRepository.News[0]));
        }

        [TestMethod]
        public void NewsList_OnRequest_ReturnsCorrectView()
        {
            HomeController controller = CreateTestHomeController();
            SearchViewModel viewModel = new SearchViewModel
            {
                SearchTerm = "",
            };

            ViewResult result = controller.NewsList(viewModel);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ViewName == "NewsList");
        }

        [TestMethod]
        public void NewsList_AfterSearch_HaveCorrectDataForNews()
        {
            FakeNewsRepository fakeNewsRepository = new FakeNewsRepository();
            HomeController controller = new HomeController(fakeNewsRepository);

            SearchViewModel viewModel = new SearchViewModel
            {
                SearchTerm = "Climate change",
            };

            ViewResult result = controller.NewsList(viewModel);

            List<NewsArticle> foundNews = ((NewsListViewModel)result.Model).NewsArticles;

            Assert.IsTrue(foundNews.Count == 1);
            Assert.IsTrue(TestHelper.NewsArticlesAreSame(foundNews[0], fakeNewsRepository.News[3]));
        }

        [TestMethod]
        public void NewsInCategory_OnRequest_ReturnsCorrectView()
        {
            HomeController controller = CreateTestHomeController();

            ViewResult result = controller.NewsInCategory(1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ViewName == "NewsList");
        }

        [TestMethod]
        public void NewsInCategory_AfterChoosingNewsCategory_HaveAllNewsForChosenCategory()
        {
            FakeNewsRepository fakeNewsRepository = new FakeNewsRepository();
            HomeController controller = new HomeController(fakeNewsRepository);

            ViewResult result = controller.NewsInCategory(1);
            List<NewsArticle> foundNews = ((NewsListViewModel)result.Model).NewsArticles;

            List<int> expectedArticles = new List<int> { 2, 1, 0 };

            Assert.IsTrue(TestHelper.AreDataAsExpected<NewsArticle>(foundNews,
                                                                    fakeNewsRepository.News,
                                                                    expectedArticles,
                                                                    TestHelper.NewsArticlesAreSame));
        }

        private HomeController CreateTestHomeController()
        {
            FakeNewsRepository fakeNewsRepository = new FakeNewsRepository();
            return new HomeController(fakeNewsRepository);
        }
    }
}
