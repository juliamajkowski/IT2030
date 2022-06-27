using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripLog.Models;

namespace TripLog.Controllers
{
    public class HomeController : Controller
    {
        private TripContext context { get; set; }

        public HomeController(TripContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var trips = context.Trips.OrderBy(t => t.Destination).ToList();
            return View(trips);

        }

    }
}
 
