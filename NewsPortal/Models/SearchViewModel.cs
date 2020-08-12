using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsPortal.Models
{
    public class SearchViewModel
    {
        public string SearchTerm { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string TextBoxClass { get; set; }

        public string ButtonClass { get; set; }
    }
}