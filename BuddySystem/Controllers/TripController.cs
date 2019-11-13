using BuddySystem.Models;
using BuddySystem.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuddySystem.Controllers
{
        [Authorize]
    public class TripController : Controller
    {
        // GET: Trip
        public ActionResult IndexForUser()
        {
            var tripService = CreateTripService();
            IEnumerable<TripListItem> model = tripService.GetTripsForCurrentUser();
            return View(model);
        }
        public ActionResult IndexAllTrips()
        {
            var tripService = CreateTripService();
            IEnumerable<TripListItem> model = tripService.GetAllTrips();
            return View(model);

        }
        //Get: Create
        public ActionResult Create()
        {
            var buddyServiceNoGuid = CreateBuddyServiceNoGuid();
            var listOfBuddies = buddyServiceNoGuid.GetAllBuddies();
            var model = new TripCreate()
            {
                ListOfAllBuddies = listOfBuddies
            };
            return View(model);
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

            var service = CreateTripService();
            if (service.CreateTrip(model))
            {

                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "Trip could not be created");
            return View(model);
        }


        private TripService CreateTripService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TripService(userId);
            return service;
        }
        private BuddyService CreateBuddyServiceNoGuid()
        {
            var buddyServiceNoGuid = new BuddyService();
            return buddyServiceNoGuid;
        }
    }
}