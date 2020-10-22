using Bogus;
using System;

namespace VueJSTest01
{
    public class WebsitePage
    {
        public int Id { get; set; }
        /// <summary>
        /// page name / site name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 0 - all
        /// 1 - site
        /// 2 - page
        /// </summary>
        public WebsitePageType Type { get; set; }

        public DateTime ModifiedDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool Starred { get; set; }
        public bool Trash { get; set; }

        public WebsitePageAccount Owner { get; set; }

        /// <summary>Gets the fake data.</summary>
        /// <value>The fake data.</value>
        public static Faker<WebsitePage> FakeData { get; } =
            new Faker<WebsitePage>()
                .RuleFor(p => p.Id, f => f.UniqueIndex)
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Type, f => f.PickRandom<WebsitePageType>())
                .RuleFor(p => p.CreatedDate, f => f.Date.Past(18))
                .RuleFor(p => p.ModifiedDate, f => f.Date.Past(18))
                .RuleFor(p => p.Starred, f => f.PickRandom(new bool[] { true, false }))
                .RuleFor(p => p.Trash, f => f.PickRandom(new bool[] { true, false }));
    }
}
