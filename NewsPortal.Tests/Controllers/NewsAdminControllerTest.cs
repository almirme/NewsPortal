using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsPortal.Controllers;

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
        public void IndexAdmin_OnRequest_()
        {
        }

    }
}
