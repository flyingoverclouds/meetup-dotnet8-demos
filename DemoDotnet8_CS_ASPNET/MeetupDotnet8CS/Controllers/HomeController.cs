using MeetupDotnet8CS.Keyed;
using MeetupDotnet8CS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MeetupDotnet8CS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMathCompute _calculette;
        private readonly IServiceProvider _serviceProvider;
        public HomeController(ILogger<HomeController> logger,
            [FromKeyedServices("add")]IMathCompute calculette,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _calculette = calculette;
            _serviceProvider = serviceProvider;
        }

        public IActionResult Index()
        {
            ViewData["res"] = _calculette.DoCompute(3, 2);

            var calculette2 = _serviceProvider.GetRequiredKeyedService<IMathCompute>("mul");
            ViewData["res2"] = calculette2.DoCompute(3, 2);

            return View();
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
