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
    }
}