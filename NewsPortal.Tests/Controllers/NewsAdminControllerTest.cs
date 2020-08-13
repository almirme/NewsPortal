using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewsPortal.Controllers;
using NewsPortal.Models;
using NewsPortal.Tests.Fakes;

namespace NewsPortal.Tests.Controllers
{
    [TestClass]
    public class NewsAdminControllerTest
    {
        [TestMethod]
        public void AllActionsInControllerAreAccessibleOnlyByAuthorizedUsers()
        {
            var controller = new NewsAdminController(null);
            var type = controller.GetType();
            object[] attributes = type.GetCustomAttributes(typeof(AuthorizeAttribute), false);
            
            Assert.IsTrue(attributes.Length == 1, "AuthorizeAttribute not found on Controller class");
        }

        [TestMethod]
        public void IndexAdmin_OnRequest_ReturnsCorrectView()
        {
            FakeNewsRepository fakeNewsRepository = new FakeNewsRepository();
            NewsAdminController controller = CreateNewsAdminController(fakeNewsRepository);
            SearchViewModel viewModel = new SearchViewModel();

            ViewResult result = controller.IndexAdmin(viewModel);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ViewName == "IndexAdmin");
        }

        [TestMethod]
        public void IndexAdmin_OnRequest_ReturnAllNewsForUser()
        {
            FakeNewsRepository fakeNewsRepository = new FakeNewsRepository();
            NewsAdminController controller = CreateNewsAdminController(fakeNewsRepository);
            SearchViewModel viewModel = new SearchViewModel();

            ViewResult result = controller.IndexAdmin(viewModel);
            List<NewsArticle> articlesByUser = ((IEnumerable<NewsArticle>)result.Model).ToList();

            List<int> expectedArticlesForUser = new List<int> { 0, 1, 2 };

            Assert.IsTrue(TestHelper.AreDataAsExpected(articlesByUser,
                                                       fakeNewsRepository.News,
                                                       expectedArticlesForUser,
                                                       TestHelper.NewsArticlesAreSame));
        }

        public void IndexAdmin_OnUserSearch_ReturnNewsThatContainSearchTerm()
        {
            FakeNewsRepository fakeNewsRepository = new FakeNewsRepository();
            NewsAdminController controller = CreateNewsAdminController(fakeNewsRepository);
            SearchViewModel viewModel = new SearchViewModel() { SearchTerm = "Lebanon" };

            ViewResult result = controller.IndexAdmin(viewModel);
            List<NewsArticle> articlesByUser = ((IEnumerable<NewsArticle>)result.Model).ToList();

            List<int> expectedArticlesForUser = new List<int> { 0 };

            Assert.IsTrue(TestHelper.AreDataAsExpected(articlesByUser,
                                                       fakeNewsRepository.News,
                                                       expectedArticlesForUser,
                                                       TestHelper.NewsArticlesAreSame));
        }

        [TestMethod]
        public void NewNews_OnRequest_ReturnsCorrectView()
        {
            FakeNewsRepository fakeNewsRepository = new FakeNewsRepository();
            NewsAdminController controller = CreateNewsAdminController(fakeNewsRepository);

            ViewResult result = controller.NewNews();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ViewName == "NewsForm");
        }

        [TestMethod]
        public void NewNews_OnRequest_HaveEmptyArticleAndAllCategories()
        {
            FakeNewsRepository fakeNewsRepository = new FakeNewsRepository();
            NewsAdminController controller = CreateNewsAdminController(fakeNewsRepository);

            ViewResult result = controller.NewNews();

            NewsFormViewModel viewModel = (NewsFormViewModel)result.Model;

            List<int> expectedCategories = new List<int> { 0, 1, 2, 3, 4 };

            Assert.IsTrue(TestHelper.NewsArticlesAreSame(viewModel.NewsArticle, new NewsArticle()));
            Assert.IsTrue(TestHelper.AreDataAsExpected<NewsCategory>(viewModel.NewsCategories.ToList(),
                                                                     fakeNewsRepository.Categories,
                                                                     expectedCategories,
                                                                     TestHelper.NewsCategoriesAreSame));
        }

        [TestMethod]
        public void EditNews_OnRequest_ReturnsCorrectView()
        {
            FakeNewsRepository fakeNewsRepository = new FakeNewsRepository();
            NewsAdminController controller = CreateNewsAdminController(fakeNewsRepository);

            ViewResult result = controller.EditNews(2) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ViewName == "NewsForm");
        }

        [TestMethod]
        public void EditNews_OnRequestForEdit_HaveCorrectArticleForEdit()
        {
            FakeNewsRepository fakeNewsRepository = new FakeNewsRepository();
            NewsAdminController controller = CreateNewsAdminController(fakeNewsRepository);

            ViewResult result = controller.EditNews(2) as ViewResult;
            NewsArticle editArticle = ((NewsFormViewModel)result.Model).NewsArticle;

            Assert.IsTrue(TestHelper.NewsArticlesAreSame(editArticle, fakeNewsRepository.News[1]));
        }

        [TestMethod]
        public void EditNews_OnRequestForEditNonExistingArticle_Redirected()
        {
            FakeNewsRepository fakeNewsRepository = new FakeNewsRepository();
            NewsAdminController controller = CreateNewsAdminController(fakeNewsRepository);

            object result = controller.EditNews(int.MaxValue);

            Assert.IsTrue(result is HttpNotFoundResult);
        }

        [TestMethod]
        public void Save_AfterSavingArticle_RedirectsToTableView()
        {
            FakeNewsRepository fakeNewsRepository = new FakeNewsRepository();
            NewsAdminController controller = CreateNewsAdminController(fakeNewsRepository);

            NewsArticle existingArticle = fakeNewsRepository.News[0];

            RedirectToRouteResult result = controller.Save(existingArticle) as RedirectToRouteResult;
            
            Assert.IsNotNull(result);
            Assert.IsTrue(result.RouteValues["action"].ToString() == "IndexAdmin");
            Assert.IsTrue(result.RouteValues["controller"].ToString() == "NewsAdmin");
        }

        [TestMethod]
        public void Save_AfterSavingArticle_ArticleIsInRepository()
        {
            FakeNewsRepository fakeNewsRepository = new FakeNewsRepository();
            NewsAdminController controller = CreateNewsAdminController(fakeNewsRepository);

            string testTitle = "TestTitle";

            NewsArticle newNewsArticle = new NewsArticle();
            newNewsArticle.Id = 0;
            newNewsArticle.Title = testTitle;
            newNewsArticle.Content = "TestContent";
            newNewsArticle.Category = "TestCategory";
            newNewsArticle.PictureUrl = "TestURL";

            int previousNumberOfArticles = fakeNewsRepository.News.Count;

            RedirectToRouteResult result = controller.Save(newNewsArticle) as RedirectToRouteResult;

            NewsArticle savedArticle = fakeNewsRepository.News.Find(a => a.Title == testTitle);

            Assert.IsTrue(previousNumberOfArticles + 1 == fakeNewsRepository.News.Count);
            Assert.IsTrue(TestHelper.NewsArticlesAreSame(newNewsArticle, savedArticle));

            if (savedArticle != null)
            {
                fakeNewsRepository.News.Remove(savedArticle);
            }
        }

        [TestMethod]
        public void Save_AfterUpdatingArticle_ChangesAreInRepository()
        {
            FakeNewsRepository fakeNewsRepository = new FakeNewsRepository();
            NewsAdminController controller = CreateNewsAdminController(fakeNewsRepository);

            NewsArticle existingArticle = fakeNewsRepository.News[0];
            string oldTitle = existingArticle.Title;
            string newTitle = "TestTitle";
            existingArticle.Title = newTitle;

            RedirectToRouteResult result = controller.Save(existingArticle) as RedirectToRouteResult;

            NewsArticle savedArticle = fakeNewsRepository.News.Find(a => a.Id == existingArticle.Id);

            Assert.IsTrue(savedArticle.Title == newTitle);
        }

        private NewsAdminController CreateNewsAdminController(INewsRepository repository, string userName = "Fred Astaire")
        {
            var mock = new Mock<ControllerContext>();
            mock.SetupGet(p => p.HttpContext.User.Identity.Name).Returns(userName);
            mock.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            NewsAdminController controller = new NewsAdminController(repository);
            controller.ControllerContext = mock.Object;

            return controller;
        }

    }
}
