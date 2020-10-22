using Bogus;
using System;

namespace VueJSTest01
{
    public class WebsitePageAccount
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        /// <summary>Gets the fake data.</summary>
        /// <value>The fake data.</value>
        public static Faker<WebsitePageAccount> FakeData { get; } =
            new Faker<WebsitePageAccount>()
                .RuleFor(p => p.Id, f => f.UniqueIndex)
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.MiddleName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.FullName, (f, p) => p.FirstName + " " + p.MiddleName + " " + p.LastName)
                .RuleFor(p => p.Email, (f, p) => f.Internet.Email(p.FirstName, p.LastName));

    }
}
