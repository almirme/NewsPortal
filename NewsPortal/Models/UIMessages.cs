using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsPortal.Models
{
    public static class UIMessages
    {
        public static IUIMessages GetMessagesForLanguage()
        {
            // TODO determine language and return appropriate instance

            return UIMessagesEnglish.Instance;
        }
    }
}