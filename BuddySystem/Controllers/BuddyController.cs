using BuddySystem.Data;
using BuddySystem.Models.BuddyModels;
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
    public class BuddyController : Controller
    {
        // GET: Buddy
        public ActionResult Index()
        {
            var service = CreateBuddyService();
            var model = service.GetAllBuddies();

            return View(model);
        }

        // GET: Buddy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Buddy/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BuddyCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateBuddyService();

            if (service.CreateBuddy(model))
            {
                TempData["SaveResult"] = "Your profile was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Profile could not be created");
            return View(model);
        }

        // GET: Buddy/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateBuddyService();
            var model = service.GetBuddyById(id);
            return View(model);
        }

        // GET: Buddy/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateBuddyService();
            var detail = service.GetBuddyById(id);
            var model =
                new BuddyEdit
                {
                    BuddyId = detail.BuddyId,
                    Name = detail.Name,
                    CurrentLocation = detail.CurrentLocation,
                    IsApproved = detail.IsApproved,
                    IsMale = detail.IsMale,
                    Age = detail.Age
                };
            return View(model);
        }

        // POST: Buddy/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BuddyEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.BuddyId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateBuddyService();

            if (service.UpdateBuddy(model))
            {
                TempData["SaveResult"] = "Your profile was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your profile could not be updated.");
            return View();
        }

        // GET: Buddy/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateBuddyService();
            var model = service.GetBuddyById(id);

            return View(model);
        }

        // POST: Buddy/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateBuddyService();
            service.DeleteBuddy(id);

            TempData["SaveResult"] = "This profile was deleted.";
            return RedirectToAction("Index");
        }


        private BuddyService CreateBuddyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BuddyService(userId);
            return service;
        }

    }
}