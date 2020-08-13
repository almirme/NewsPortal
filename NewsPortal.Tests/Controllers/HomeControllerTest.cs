using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsPortal;
using NewsPortal.Controllers;
using NewsPortal.Tests.Fakes;

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
            HomeController controller = CreateTestHomeController();

            ViewResult result = controller.Index();
            //result.Model

            Assert.Fail();
        }

        [TestMethod]
        public void Index_WhenDisplayed_HaveAllNewsCategories()
        {
            HomeController controller = CreateTestHomeController();

            ViewResult result = controller.Index();
            //result.Model

            Assert.Fail();
        }

        private HomeController CreateTestHomeController()
        {
            FakeNewsRepository fakeNewsRepository = new FakeNewsRepository();
            return new HomeController(fakeNewsRepository);
        }
    }
}
