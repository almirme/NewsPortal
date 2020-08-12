using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsPortal.Controllers;

namespace NewsPortal.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void Login_OnRequest_ReturnsView()
        {
            AccountController controller = new AccountController();

            ViewResult result = controller.Login(null) as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
