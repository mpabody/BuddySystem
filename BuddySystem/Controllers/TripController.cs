using BuddySystem.Models;
using BuddySystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuddySystem.Controllers
{
    public class TripController : Controller
    {
        // GET: Trip
        public ActionResult Index()
        {
            var service = new TripService();
            var model = service.GetTrips();
            return View(model);
        }
        //Get: Create
        public ActionResult Create()
        {
            var service = new TripService();
            return View();
        }
        //Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TripCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new TripService();
            if (service.CreateTrip(model))
            {
                
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "Trip could not be created");
            return View(model);
        }
    }
}