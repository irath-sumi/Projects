using CMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Contentful.Core;
using HotChocolate.AspNetCore;
using Newtonsoft.Json;
using Contentful.Core.Search;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContentfulClient _contentfulClient;

        public HomeController(ILogger<HomeController> logger, IContentfulClient contentfulClient)
        {
            _contentfulClient = contentfulClient;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _contentfulClient.GetEntries<MoboFeaturesContentful>();
            return View(res);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}