using BuddySystem.Models;
using BuddySystem.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuddySystem.Controllers //don't think this controller is needed because additional buddies are a part of Trip, Additional Buddy functions are in Trip Controller.
{   
    //public class AdditionBuddyController : Controller
    //{
    //    // GET: AdditionBuddy
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }
  

    //    private TripService CreateTripService()
    //    {
    //        var userId = Guid.Parse(User.Identity.GetUserId());
    //        var service = new TripService(userId);
    //        return service;
    //    }
    //    private BuddyService CreateBuddyServiceNoGuid()
    //    {
    //        var buddyServiceNoGuid = new BuddyService();
    //        return buddyServiceNoGuid;
    //    }
    //}
}