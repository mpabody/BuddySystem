using BuddySystem.Models;
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
    [RoutePrefix("api/trip")]
    [Authorize]
    public class TripController : ApiController
    {
        [Route("TripsForCurrentUser")]
        public IHttpActionResult GetTripsForCurrentUser()
        {
            TripService tripService = CreateTripService();
            var trips = tripService.GetTripsForCurrentUser();
            return Ok(trips);
        }

        [Route("TripsForAllUsers")]
        public IHttpActionResult GetAllTrips()
        {
            TripService tripService = CreateTripService();
            var trips = tripService.GetAllTrips();
            return Ok(trips);
        }
        [Route("{id:int}")]
        public IHttpActionResult GetTrip(int id)
        {
            TripService tripService = CreateTripService();
            var trip = tripService.GetTripById(id);
            return Ok(trip);
        }

        // Create
        [Route("CreateTrip")]
        public IHttpActionResult Post(TripCreate trip)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTripService();

            if (!service.CreateTrip(trip))
                return InternalServerError();

            return Ok();

        }

        // Update
        public IHttpActionResult Put(TripEdit trip)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTripService();

            if (!service.UpdateTrip(trip))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateTripService();

            if (!service.DeleteTrip(id))
                return InternalServerError();

            return Ok();
        }

        //Add(Create) Additional Buddy
        [Route("api/trip/AddAdditionalBuddy")]
        public IHttpActionResult PostAdditionalBuddy(AddAdditionalBuddy additionalBuddy)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAdditionalBuddyService();

            if (!service.PostAdditionalBuddyToDataTable(additionalBuddy))
                return InternalServerError();

            return Ok();
        }

        [Route("api/trip/RemoveAdditionalBuddy")]
        public IHttpActionResult DeleteAdditionalBuddy(int buddyId)
        {
            var service = CreateAdditionalBuddyService();

            if (!service.DeleteAdditionalBuddyFromTrip(buddyId))
                return InternalServerError();

            return Ok();
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
