﻿using System;
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
            Assert.IsTrue(result.ViewName == "Index" || result.ViewName == "");
        }

        [TestMethod]
        public void Index_WhenDisplayed_HaveThreeLatestNewsForEachCategory()
        {
            FakeNewsRepository fakeNewsRepository = new FakeNewsRepository();
            HomeController controller = new HomeController(fakeNewsRepository);

            ViewResult result = controller.Index();
            var newsArticlesInView = ((CommonViewModel)result.Model).NewsArticles.ToList();

            List<int> expectedArticles = new List<int> { 2, 1, 0, 4, 5, 6, 3 };

            Assert.IsTrue(AreDataAsExpected<NewsArticle>(newsArticlesInView, 
                                                         fakeNewsRepository.News,
                                                         expectedArticles,
                                                         NewsArticlesAreSame));
        }

        [TestMethod]
        public void Index_WhenDisplayed_HaveAllNewsCategories()
        {
            FakeNewsRepository fakeNewsRepository = new FakeNewsRepository();
            HomeController controller = new HomeController(fakeNewsRepository);

            ViewResult result = controller.Index();
            var newsCategoriesInView = ((CommonViewModel)result.Model).NewsCategories.ToList();

            List<int> expectedCategories = new List<int> { 0, 1, 2, 3, 4 };

            Assert.IsTrue(AreDataAsExpected<NewsCategory>(newsCategoriesInView,
                                                          fakeNewsRepository.Categories,
                                                          expectedCategories,
                                                          NewsCategoriesAreSame));
        }

        [TestMethod]
        public void SingleNews_OnRequest_ReturnsCorrectView()
        {
            HomeController controller = CreateTestHomeController();

            ViewResult result = controller.SingleNews(1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.ViewName == "Index" || result.ViewName == "");
        }

        private HomeController CreateTestHomeController()
        {
            FakeNewsRepository fakeNewsRepository = new FakeNewsRepository();
            return new HomeController(fakeNewsRepository);
        }

        private bool NewsArticlesAreSame(NewsArticle article, NewsArticle article2)
        {
            return article.Author == article2.Author
                   && article.Category == article2.Category
                   && article.Content == article2.Content
                   && article.Id == article2.Id
                   && article.PublishDate == article2.PublishDate
                   && article.Title == article2.Title
                   && article.PictureUrl == article2.PictureUrl;
        }

        private bool NewsCategoriesAreSame(NewsCategory category, NewsCategory category2)
        {
            return category.Id == category2.Id && category.Name == category2.Name;
        }

        private bool AreDataAsExpected<T>(List<T> actualData,
                                          List<T> expectetData,
                                          List<int> expectedDataOrder,
                                          Func<T, T, bool> compare)
        {
            bool dataAreAsExpected = true;

            if (actualData.Count == expectedDataOrder.Count)
            {
                for (int i = 0; i < expectedDataOrder.Count && dataAreAsExpected; i++)
                {
                    dataAreAsExpected = compare(expectetData[expectedDataOrder[i]], 
                                                actualData[i]);
                }
            }
            else
            {
                dataAreAsExpected = false;
            }

            return dataAreAsExpected;
        }
    }
}
