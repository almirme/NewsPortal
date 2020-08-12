using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsPortal.Models
{
    public class UIMessagesEnglish : IUIMessages
    {
        private static readonly UIMessagesEnglish INSTANCE = new UIMessagesEnglish();

        private UIMessagesEnglish() { }

        public static UIMessagesEnglish Instance
        {
            get { return INSTANCE; }
        }

        public string CompanyName => "ABCD News";

        public string WelcomeToWebsiteMessage => $"Welcome to {CompanyName}";
    }
}