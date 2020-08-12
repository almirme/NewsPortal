using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsPortal.Models;

namespace NewsPortal.Tests.Models
{
    [TestClass]
    public class UIMessagesTest
    {
        [TestMethod]
        public void UIMessages_DefaultLanguage_ReturnsCorrectWelcomeMessage()
        {
            IUIMessages uIMessages = UIMessages.GetMessagesForLanguage();

            string expectedMessage = uIMessages.WelcomeToWebsiteMessage;

            Assert.AreEqual(expectedMessage, "Welcome to ABCD News");
        }
    }
}
