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
    [RoutePrefix("api/buddy")]
    [Authorize]
    public class BuddyController : ApiController
    {
        // xxxxx/api/buddy
        public IHttpActionResult GetAllBuddies()
        {
            var buddyService = CreateBuddyService();
            var buddies = buddyService.GetAllBuddies();
            return Ok(buddies);
        }
        // xxxxx/api/buddy/id
        public IHttpActionResult GetBuddy(int id)
        {
            var buddyService = CreateBuddyService();
            var buddy = buddyService.GetBuddyById(id);
            return Ok(buddy);
        }

        [Route("CurrentUserBuddy")]
        public IHttpActionResult GetCurrentUserBuddy()
        {
            var buddyService = CreateBuddyService();
            var buddy = buddyService.GetCurrentUserBuddy();
            return Ok(buddy);
        }

       // Create
        public IHttpActionResult Post(BuddyCreate buddy)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBuddyService();

            if (!service.CreateBuddy(buddy))
                return InternalServerError();

            return Ok();
        }

        // Update
        public IHttpActionResult Put(BuddyEdit buddy)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateBuddyService();

            if (!service.UpdateBuddy(buddy))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateBuddyService();

            if (!service.DeleteBuddy(id))
                return InternalServerError();

            return Ok();
        }


        private BuddyService CreateBuddyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BuddyService(userId);
            return service;
        }
    }
}
