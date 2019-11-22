using BuddySystem.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BuddySystem_WebAPI.Controllers
{
    [Authorize]
    public class TripController : ApiController
    {
        public IHttpActionResult GetTripsForUser()
        {
            TripService tripService = CreateTripService();
            var trips = tripService.GetTripsForCurrentUser();
            return Ok(trips);
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
