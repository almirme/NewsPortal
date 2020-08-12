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
            List<NewsArticle> articlesByDate = _inMemoryNews.OrderBy(article => article.PublishDate).ToList();
            return articlesByDate.GetRange(0, numberOfLatestNews);
        }

        public void AddNew(NewsArticle newsArticle)
        {
            _inMemoryNews.Add(newsArticle);
        }

        public void Update(NewsArticle newsArticle)
        {
            int articleInDbIndex = _inMemoryNews.FindIndex(article => article.Id == newsArticle.Id);

            _inMemoryNews[articleInDbIndex].Title = newsArticle.Title;
            _inMemoryNews[articleInDbIndex].Author = newsArticle.Author;
            _inMemoryNews[articleInDbIndex].PublishDate = newsArticle.PublishDate;
            _inMemoryNews[articleInDbIndex].Content = newsArticle.Content;
            _inMemoryNews[articleInDbIndex].PictureUrl = newsArticle.PictureUrl;
            _inMemoryNews[articleInDbIndex].Category = newsArticle.Category;
        }

        public NewsArticle GetById(int id)
        {
            return _inMemoryNews.Find(article => article.Id == id);
        }

        public IEnumerable<NewsArticle> GetAllForUser(string userFullName)
        {
            return _inMemoryNews.FindAll(article => article.Author == userFullName);
        }

        static string fred = "Fred Astaire";
        static string marlon = "Marlon Brando";
        static string barbara = "Barbara Stanwyck";

        static string politics = "Politics";
        static string science = "Science & Environment";
        static string business = "Business";

        List<NewsArticle> _inMemoryNews = new List<NewsArticle>()
        {
            new NewsArticle()
            {
                Id = 1,
                Author = fred,
                Category = politics,
                Content = "Donec vitae cursus lorem. Nam convallis aliquet nisl. Aliquam vulputate, velit nec pellentesque eleifend, nisl lorem iaculis nisl, vel dignissim ipsum purus pretium quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin eget tristique nisl. Nulla nulla nisl, sollicitudin vel blandit et, pharetra in purus. In nec odio a justo gravida congue et sed massa. Nam rhoncus lacus ipsum, pulvinar efficitur nulla varius vel. Nulla consectetur accumsan metus non pharetra. Sed risus est, commodo at elementum quis, rutrum a lectus. Praesent vel porta enim, sit amet tincidunt erat. Etiam id leo pellentesque dui fringilla dapibus. Vestibulum nulla nisi, auctor congue enim nec, condimentum facilisis arcu. Sed viverra mauris et ligula tincidunt, sit amet tempor sem iaculis. Integer auctor sodales ex, et consectetur mauris maximus a. Nullam sollicitudin lectus et placerat feugiat. Ut imperdiet bibendum libero sit amet dapibus. Sed a ex congue, lobortis turpis ut, sagittis libero. Sed aliquet mauris non quam efficitur, quis pretium lectus iaculis. Nullam dolor nibh, finibus vel enim vitae, accumsan lacinia dolor. Quisque sed dui felis. Morbi sed tincidunt arcu, non ullamcorper ante. Sed placerat facilisis ipsum blandit blandit. Vivamus consectetur euismod dolor, ac finibus nisi pulvinar lobortis. Nulla libero sem, vulputate id enim id, ultricies maximus mi. Morbi in metus finibus, congue mi et, imperdiet ex.",
                Title = "Lebanon president accepts gov't resignation after Beirut blast",
                PublishDate = new DateTime(2020, 8, 10, 12, 50, 0),
                PictureUrl = "https://ichef.bbci.co.uk/news/660/cpsprodpb/12C89/production/_113873967_gettyimages-1227949265-1.jpg"
            },
            new NewsArticle()
            {
                Id = 2,
                Author = fred,
                Category = politics,
                Content = "Donec vitae cursus lorem. Nam convallis aliquet nisl. Aliquam vulputate, velit nec pellentesque eleifend, nisl lorem iaculis nisl, vel dignissim ipsum purus pretium quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin eget tristique nisl. Nulla nulla nisl, sollicitudin vel blandit et, pharetra in purus. In nec odio a justo gravida congue et sed massa. Nam rhoncus lacus ipsum, pulvinar efficitur nulla varius vel. Nulla consectetur accumsan metus non pharetra. Sed risus est, commodo at elementum quis, rutrum a lectus. Praesent vel porta enim, sit amet tincidunt erat. Etiam id leo pellentesque dui fringilla dapibus. Vestibulum nulla nisi, auctor congue enim nec, condimentum facilisis arcu. Sed viverra mauris et ligula tincidunt, sit amet tempor sem iaculis. Integer auctor sodales ex, et consectetur mauris maximus a. Nullam sollicitudin lectus et placerat feugiat. Ut imperdiet bibendum libero sit amet dapibus. Sed a ex congue, lobortis turpis ut, sagittis libero. Sed aliquet mauris non quam efficitur, quis pretium lectus iaculis. Nullam dolor nibh, finibus vel enim vitae, accumsan lacinia dolor. Quisque sed dui felis. Morbi sed tincidunt arcu, non ullamcorper ante. Sed placerat facilisis ipsum blandit blandit. Vivamus consectetur euismod dolor, ac finibus nisi pulvinar lobortis. Nulla libero sem, vulputate id enim id, ultricies maximus mi. Morbi in metus finibus, congue mi et, imperdiet ex.",
                Title = "Trump's COVID-19 unemployment plan confuses US state governors",
                PublishDate = new DateTime(2020, 8, 10, 13, 28, 0),
                PictureUrl = "https://ichef.bbci.co.uk/news/660/cpsprodpb/166EF/production/_113878819_gettyimages-1212273524.jpg"
            },
            new NewsArticle()
            {
                Id = 3,
                Author = fred,
                Category = politics,
                Content = "Donec vitae cursus lorem. Nam convallis aliquet nisl. Aliquam vulputate, velit nec pellentesque eleifend, nisl lorem iaculis nisl, vel dignissim ipsum purus pretium quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin eget tristique nisl. Nulla nulla nisl, sollicitudin vel blandit et, pharetra in purus. In nec odio a justo gravida congue et sed massa. Nam rhoncus lacus ipsum, pulvinar efficitur nulla varius vel. Nulla consectetur accumsan metus non pharetra. Sed risus est, commodo at elementum quis, rutrum a lectus. Praesent vel porta enim, sit amet tincidunt erat. Etiam id leo pellentesque dui fringilla dapibus. Vestibulum nulla nisi, auctor congue enim nec, condimentum facilisis arcu. Sed viverra mauris et ligula tincidunt, sit amet tempor sem iaculis. Integer auctor sodales ex, et consectetur mauris maximus a. Nullam sollicitudin lectus et placerat feugiat. Ut imperdiet bibendum libero sit amet dapibus. Sed a ex congue, lobortis turpis ut, sagittis libero. Sed aliquet mauris non quam efficitur, quis pretium lectus iaculis. Nullam dolor nibh, finibus vel enim vitae, accumsan lacinia dolor. Quisque sed dui felis. Morbi sed tincidunt arcu, non ullamcorper ante. Sed placerat facilisis ipsum blandit blandit. Vivamus consectetur euismod dolor, ac finibus nisi pulvinar lobortis. Nulla libero sem, vulputate id enim id, ultricies maximus mi. Morbi in metus finibus, congue mi et, imperdiet ex.",
                Title = "Takeaway food to electronics: UK consumer spending jumped in July",
                PublishDate = new DateTime(2020, 8, 11, 8, 37, 0),
                PictureUrl = "https://ichef.bbci.co.uk/news/660/cpsprodpb/111AA/production/_113885007_062846707-1.jpg"
            },
            new NewsArticle()
            {
                Id = 4,
                Author = marlon,
                Category = science,
                Content = "Donec vitae cursus lorem. Nam convallis aliquet nisl. Aliquam vulputate, velit nec pellentesque eleifend, nisl lorem iaculis nisl, vel dignissim ipsum purus pretium quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin eget tristique nisl. Nulla nulla nisl, sollicitudin vel blandit et, pharetra in purus. In nec odio a justo gravida congue et sed massa. Nam rhoncus lacus ipsum, pulvinar efficitur nulla varius vel. Nulla consectetur accumsan metus non pharetra. Sed risus est, commodo at elementum quis, rutrum a lectus. Praesent vel porta enim, sit amet tincidunt erat. Etiam id leo pellentesque dui fringilla dapibus. Vestibulum nulla nisi, auctor congue enim nec, condimentum facilisis arcu. Sed viverra mauris et ligula tincidunt, sit amet tempor sem iaculis. Integer auctor sodales ex, et consectetur mauris maximus a. Nullam sollicitudin lectus et placerat feugiat. Ut imperdiet bibendum libero sit amet dapibus. Sed a ex congue, lobortis turpis ut, sagittis libero. Sed aliquet mauris non quam efficitur, quis pretium lectus iaculis. Nullam dolor nibh, finibus vel enim vitae, accumsan lacinia dolor. Quisque sed dui felis. Morbi sed tincidunt arcu, non ullamcorper ante. Sed placerat facilisis ipsum blandit blandit. Vivamus consectetur euismod dolor, ac finibus nisi pulvinar lobortis. Nulla libero sem, vulputate id enim id, ultricies maximus mi. Morbi in metus finibus, congue mi et, imperdiet ex.",
                Title = "Climate change: Satellites record history of Antarctic melting",
                PublishDate = new DateTime(2020, 8, 10, 11, 3, 0),
                PictureUrl = ""
            },
            new NewsArticle()
            {
                Id = 5,
                Author = barbara,
                Category = business,
                Content = "Donec vitae cursus lorem. Nam convallis aliquet nisl. Aliquam vulputate, velit nec pellentesque eleifend, nisl lorem iaculis nisl, vel dignissim ipsum purus pretium quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin eget tristique nisl. Nulla nulla nisl, sollicitudin vel blandit et, pharetra in purus. In nec odio a justo gravida congue et sed massa. Nam rhoncus lacus ipsum, pulvinar efficitur nulla varius vel. Nulla consectetur accumsan metus non pharetra. Sed risus est, commodo at elementum quis, rutrum a lectus. Praesent vel porta enim, sit amet tincidunt erat. Etiam id leo pellentesque dui fringilla dapibus. Vestibulum nulla nisi, auctor congue enim nec, condimentum facilisis arcu. Sed viverra mauris et ligula tincidunt, sit amet tempor sem iaculis. Integer auctor sodales ex, et consectetur mauris maximus a. Nullam sollicitudin lectus et placerat feugiat. Ut imperdiet bibendum libero sit amet dapibus. Sed a ex congue, lobortis turpis ut, sagittis libero. Sed aliquet mauris non quam efficitur, quis pretium lectus iaculis. Nullam dolor nibh, finibus vel enim vitae, accumsan lacinia dolor. Quisque sed dui felis. Morbi sed tincidunt arcu, non ullamcorper ante. Sed placerat facilisis ipsum blandit blandit. Vivamus consectetur euismod dolor, ac finibus nisi pulvinar lobortis. Nulla libero sem, vulputate id enim id, ultricies maximus mi. Morbi in metus finibus, congue mi et, imperdiet ex.",
                Title = "The headphones that even a DJ can't break?",
                PublishDate = new DateTime(2020, 8, 11, 15, 57, 0),
                PictureUrl = ""
            },
            new NewsArticle()
            {
                Id = 6,
                Author = barbara,
                Category = business,
                Content = "Donec vitae cursus lorem. Nam convallis aliquet nisl. Aliquam vulputate, velit nec pellentesque eleifend, nisl lorem iaculis nisl, vel dignissim ipsum purus pretium quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin eget tristique nisl. Nulla nulla nisl, sollicitudin vel blandit et, pharetra in purus. In nec odio a justo gravida congue et sed massa. Nam rhoncus lacus ipsum, pulvinar efficitur nulla varius vel. Nulla consectetur accumsan metus non pharetra. Sed risus est, commodo at elementum quis, rutrum a lectus. Praesent vel porta enim, sit amet tincidunt erat. Etiam id leo pellentesque dui fringilla dapibus. Vestibulum nulla nisi, auctor congue enim nec, condimentum facilisis arcu. Sed viverra mauris et ligula tincidunt, sit amet tempor sem iaculis. Integer auctor sodales ex, et consectetur mauris maximus a. Nullam sollicitudin lectus et placerat feugiat. Ut imperdiet bibendum libero sit amet dapibus. Sed a ex congue, lobortis turpis ut, sagittis libero. Sed aliquet mauris non quam efficitur, quis pretium lectus iaculis. Nullam dolor nibh, finibus vel enim vitae, accumsan lacinia dolor. Quisque sed dui felis. Morbi sed tincidunt arcu, non ullamcorper ante. Sed placerat facilisis ipsum blandit blandit. Vivamus consectetur euismod dolor, ac finibus nisi pulvinar lobortis. Nulla libero sem, vulputate id enim id, ultricies maximus mi. Morbi in metus finibus, congue mi et, imperdiet ex.",
                Title = "Twitter 'looking' at a possible TikTok tie-up",
                PublishDate = new DateTime(2020, 8, 11, 12, 50, 0),
                PictureUrl = ""
            },
            new NewsArticle()
            {
                Id = 7,
                Author = marlon,
                Category = science,
                Content = "Donec vitae cursus lorem. Nam convallis aliquet nisl. Aliquam vulputate, velit nec pellentesque eleifend, nisl lorem iaculis nisl, vel dignissim ipsum purus pretium quam. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin eget tristique nisl. Nulla nulla nisl, sollicitudin vel blandit et, pharetra in purus. In nec odio a justo gravida congue et sed massa. Nam rhoncus lacus ipsum, pulvinar efficitur nulla varius vel. Nulla consectetur accumsan metus non pharetra. Sed risus est, commodo at elementum quis, rutrum a lectus. Praesent vel porta enim, sit amet tincidunt erat. Etiam id leo pellentesque dui fringilla dapibus. Vestibulum nulla nisi, auctor congue enim nec, condimentum facilisis arcu. Sed viverra mauris et ligula tincidunt, sit amet tempor sem iaculis. Integer auctor sodales ex, et consectetur mauris maximus a. Nullam sollicitudin lectus et placerat feugiat. Ut imperdiet bibendum libero sit amet dapibus. Sed a ex congue, lobortis turpis ut, sagittis libero. Sed aliquet mauris non quam efficitur, quis pretium lectus iaculis. Nullam dolor nibh, finibus vel enim vitae, accumsan lacinia dolor. Quisque sed dui felis. Morbi sed tincidunt arcu, non ullamcorper ante. Sed placerat facilisis ipsum blandit blandit. Vivamus consectetur euismod dolor, ac finibus nisi pulvinar lobortis. Nulla libero sem, vulputate id enim id, ultricies maximus mi. Morbi in metus finibus, congue mi et, imperdiet ex.",
                Title = "Detectorist 'shaking with happiness' after Bronze Age find",
                PublishDate = new DateTime(2020, 8, 10, 12, 50, 0),
                PictureUrl = ""
            },
        };
    }
}
