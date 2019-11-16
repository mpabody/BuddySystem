﻿using BuddySystem.Models;
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
                    PrimaryBuddyId = detail.PrimaryBuddyId,
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