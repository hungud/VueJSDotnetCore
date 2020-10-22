using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace VueJSTest01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebsitePageController : ControllerBase
    {
        private static List<WebsitePage> websitePages;

        private static List<WebsitePageAccount> websitePageAccount;

        private readonly ILogger<WeatherForecastController> _logger;

        static WebsitePageController()
        {
            // FAKE DATA
            websitePageAccount = WebsitePageAccount.FakeData.Generate(10);
            websitePages = WebsitePage.FakeData.Generate(100).ToList();
            foreach (var item in websitePages)
            {
                item.Owner = websitePageAccount.ElementAt(new Random().Next(0, websitePageAccount.Count));
            }
        }

        public WebsitePageController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<WebsitePage> Get()
        {
            return websitePages;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<WebsitePageAccount> GetListWebsitePageAccount()
        {
            return websitePageAccount;
        }
    }
}
