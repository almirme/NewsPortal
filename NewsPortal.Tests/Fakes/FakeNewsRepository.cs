using NewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Tests.Fakes
{
    class FakeNewsRepository : INewsRepository
    {
        public IEnumerable<NewsArticle> GetLatest(int numberOfLatestNews)
        {
            throw new NotImplementedException();
        }
    }
}
