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

        public string Search => "Search";

        public string Edit => "Edit";

        public string SearchResultFor => "Search Result For";

        public string YourNews => "Your News";

        public string AddNewUser => "Add New User";
    }
}