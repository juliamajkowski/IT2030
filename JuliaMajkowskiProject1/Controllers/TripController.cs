using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TripLog.Models;

namespace TripLog.Controllers
{
    public class TripController : Controller
    {
        private TripContext context { get; set; }

        public TripController(TripContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Trip());

        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            ViewBag.Action = "Edit";
            var trip = context.Trips.Find(Id);
            return View(trip);
        }

        [HttpPost]
        public IActionResult Edit(Trip trip)
        {
            TempData.Clear();

            TempData["destination"] = trip.Destination;
            TempData["accomidations"] = trip.Accomidations;
            TempData["startDate"] = trip.StartDate;
            TempData["endDate"] = trip.EndDate;
            TempData["adding"] = true;

            if (ModelState.IsValid)
            {
                string action;
                string controller;
                if (trip.Id == 0 && trip.Accomidations != null)
                {
                    action = "NextInfo";
                    controller = "Trip";
                }
                else if (trip.Id == 0  && trip.Accomidations == null)
                {
                    action = "NextToDo";
                    controller = "Trip";
                }
                else
                {
                    context.Trips.Update(trip);
                    action = "Index";
                    controller = "Home";
                    TempData["adding"] = false;
                }
                context.SaveChanges();
                return RedirectToAction(action, controller);
            }
            else
            {
                ViewBag.Action = (trip.Id == 0) ? "Add" : "Edit";
                return View(trip);
            }
        }

        [HttpGet]
        public IActionResult NextInfo(int Id)
        {
            ViewBag.Action = "NextInfo";
            return View();
        }

        [HttpPost]
        public IActionResult NextInfo(Trip trip)
        {
            bool adding = bool.Parse(TempData["adding"].ToString());
            if (!adding)
                context.Trips.Update(trip);
            else
            {
                TempData["accomidationPhone"] = trip.AccomidationPhone;
                TempData["accomidationEmail"] = trip.AccomidationEmail;
            }
            context.SaveChanges();
            return RedirectToAction(adding ? "NextToDo" : "Index", adding ? "Trip" : "Home");
        }
        [HttpGet]
        public IActionResult NextToDo(int Id)
        {
            ViewBag.Action = "NextToDo";
            //var trip = context.Trips.Find(Id);
            return View();
        }

        [HttpPost]
        public IActionResult NextToDo(Trip trip)
        {
            if (!bool.Parse(TempData["adding"].ToString()))
                context.Trips.Update(trip);
            else
            {
                var newTrip = new Trip
                {
                    Destination = GetTempData("destination"),
                    Accomidations = GetTempData("accomidations"),
                    StartDate = GetTempData("startDate"),
                    EndDate = GetTempData("endDate"),
                    AccomidationPhone = GetTempData("accomidationPhone"),
                    AccomidationEmail = GetTempData("accomidationEmail"),
                    ThingsToDo1 = trip.ThingsToDo1,
                    ThingsToDo2 = trip.ThingsToDo2,
                    ThingsToDo3 = trip.ThingsToDo3,
                };
                context.Trips.Add(newTrip);
            }

            context.SaveChanges();
            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }
        
        private string GetTempData(string key)
        {
            return TempData[key] == null ? null : TempData[key].ToString();
        }
    }
}