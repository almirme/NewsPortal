using NewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Tests
{
    class TestHelper
    {
        public static bool NewsArticlesAreSame(NewsArticle article, NewsArticle article2)
        {
            return article.Author == article2.Author
                   && article.Category == article2.Category
                   && article.Content == article2.Content
                   && article.Id == article2.Id
                   && article.PublishDate == article2.PublishDate
                   && article.Title == article2.Title
                   && article.PictureUrl == article2.PictureUrl;
        }

        public static bool NewsCategoriesAreSame(NewsCategory category, NewsCategory category2)
        {
            return category.Id == category2.Id && category.Name == category2.Name;
        }

        public static bool AreDataAsExpected<T>(List<T> actualData,
                                                List<T> expectetData,
                                                List<int> expectedDataOrder,
                                                Func<T, T, bool> compare)
        {
            bool dataAreAsExpected = true;

            if (actualData.Count == expectedDataOrder.Count)
            {
                for (int i = 0; i < expectedDataOrder.Count && dataAreAsExpected; i++)
                {
                    dataAreAsExpected = compare(expectetData[expectedDataOrder[i]],
                                                actualData[i]);
                }
            }
            else
            {
                dataAreAsExpected = false;
            }

            return dataAreAsExpected;
        }
    }
}
