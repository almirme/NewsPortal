using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsPortal.Common
{
    /// <summary>
    /// Strongly-typed list of Views
    /// </summary>
    public static class ViewName
    {
        public static string Home_Index => "Index";

        public static string Home_NewsList => "NewsList";

        public static string NewsAdmin_Index => "IndexAdmin";

        public static string NewsAdmin_NewsForm => "NewsForm";
    }
}