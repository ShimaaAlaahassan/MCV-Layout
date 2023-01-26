using MCV_Layout.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MCV_Layout.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("partyInfo");
        }

        public IActionResult showGuests()
        {
            List<Guests> guests = SampleData.guests;
            return View("showGuests", guests);
        }
        public IActionResult appForm()
        {
            return View("appForm");
        }
        public IActionResult addtoGuests(Guests g)
        {
            SampleData.guests.Add(g);
            List<Guests> guests = SampleData.guests;
            View("showGuests", guests);
            if (g.willAttend == "yes")
            {
                return View("thankyou");
            }
            else
            {
                return View("seeYouLater");
            }

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