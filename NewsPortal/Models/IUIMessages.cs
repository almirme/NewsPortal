using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Models
{
    public interface IUIMessages
    {
        string CompanyName { get; }

        string WelcomeToWebsiteMessage { get; }

        string Search { get; }

        string Edit { get; }

        string SearchResultFor { get; }

        string YourNews { get; }

        string AddNewUser { get; }
    }
}
