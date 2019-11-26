using BuddySystem.Models;
//using BuddySystem.Models.AdditionalBuddy; intellisense required this using statement, but BuddySystem.Models works for Trip Models... why? maybe I'm overlooking something CW
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
            
            ViewBag.ListOfAllBuddies = listOfBuddies;
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

            var service = CreateTripService();
            if (service.CreateTrip(model))
            {

                return RedirectToAction("IndexAllTrips");
            }
            else
                ModelState.AddModelError("", "Trip could not be created");
            return View(model);
        }

        //Get : Trip/Edit/{id}
        public ActionResult Edit (int id)
        {
            var service = CreateTripService();
            var detail = service.GetTripById(id);
            var model =
                new TripEdit
                {
                    TripId = detail.TripId,
                    StartTime = detail.StartTime,
                    BuddyId = detail.BuddyId,
                    VolunteerId = detail.VolunteerId,
                    StartLocation = detail.StartLocation,
                    ProjectedEndLocation = detail.ProjectedEndLocation,
                    EndLocation = detail.EndLocation,
                    EndTime = detail.EndTime
                };
            return View(model);
        }

        //Post : Trip/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TripEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.TripId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTripService();

            if (service.UpdateTrip(model))
            {
                TempData["SaveResult"] = "Your trip was updated.";
                return RedirectToAction("IndexAllTrips");
            }

            ModelState.AddModelError("", "Your trip could not be updated.");
            return View();
        }

        // GET: Trip/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateTripService();
            var model = service.GetTripById(id);
            return View(model);
        }

        // GET: Trip/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateTripService();
            var model = service.GetTripById(id);

            return View(model);
        }

        // POST: Trip/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTripService();
            service.DeleteTrip(id);

            TempData["SaveResult"] = "This profile was deleted.";
            return RedirectToAction("IndexAllTrips");
        }

        //Get: Trip/AddAdditionBuddy/{id}       Gets a model with trip Id & some details from button click -- need to add button to detail/index views
        public ActionResult AddAdditionalBuddy(int id)
        {
            var additionalBuddyService = CreateAdditionalBuddyService();
            var model = additionalBuddyService.GetAddAdditionalBuddyModel(id);
            ViewBag.ListOfAllBuddies = CreateBuddyServiceNoGuid().GetAllBuddies();
            
            return View(model);
        }

        //Post: Trip/Details{id} double check that its directing to proper views... won't matter in API probably
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAdditionalBuddy(AddAdditionalBuddy model)
        {
           // var artistService = NewArtistService();
            if (!ModelState.IsValid)
            {
                ViewBag.AdditionalBuddyID = new SelectList(CreateBuddyServiceNoGuid().GetAllBuddies(), "BuddyId", "Name");
                ViewBag.ListOfAllBuddies = CreateBuddyServiceNoGuid().GetAllBuddies();
                return View(model);
            }

            if (CreateAdditionalBuddyService().PostAdditionalBuddyToDataTable(model))
            {
                //TempData["SaveResult"] = "Buddy was added to Trip.";
                var id = model.TripId;
                return RedirectToAction("Details", new { id = model.TripId });
            }
            else
                ModelState.AddModelError("", "Buddy could not be added");
            return RedirectToAction("IndexAllTrips");
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
        private AdditionalBuddyService CreateAdditionalBuddyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var additionalBuddyService = new AdditionalBuddyService(userId);
            return additionalBuddyService;
        }
    }
}