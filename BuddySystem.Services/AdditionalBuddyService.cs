using System;
using BuddySystem.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuddySystem.Models;
using BuddySystem.Models.AdditionalBuddy;

namespace BuddySystem.Services
{
    public class AdditionalBuddyService
    {   // Gets the trip and creates the model that allows us to add a buddy to a specific trip
        private readonly Guid _userId;
        public AdditionalBuddyService(Guid userId)
        {
            _userId = userId;
        }
        // public AdditionalBuddyService() { }
        public AddAdditionalBuddy GetAddAdditionalBuddyModel(int tripId)
        {
            var tripService = new TripService(_userId);
            var tripDetail = tripService.GetTripById(tripId);
            var addBuddy = new AddAdditionalBuddy()
            {
                TripId = tripDetail.TripId,
                BuddyName = tripDetail.BuddyName,
                VolunteerName = tripDetail.VolunteerName,
                StartLocation = tripDetail.StartLocation,
                ProjectedEndLocation = tripDetail.ProjectedEndLocation
            };
            return addBuddy;

        }

        public bool PostAdditionalBuddyToDataTable(AddAdditionalBuddy model)
        {
            var entity = new AdditionalBuddy()
            {
                TripId = model.TripId,
                BuddyId = model.BuddyId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.AdditionalBuddies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAdditionalBuddyFromTrip(int additionalBuddyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .AdditionalBuddies
                        .SingleOrDefault(a => a.AdditionalBuddyId == additionalBuddyId);
                ctx.AdditionalBuddies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        public AdditionalBuddyDetail GetAdditionalBuddyById(int additionalBuddyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .AdditionalBuddies
                        .SingleOrDefault(a => a.AdditionalBuddyId == additionalBuddyId);

                var additionalBuddyDetail = new AdditionalBuddyDetail()
                {
                    AdditionalBuddyId = entity.AdditionalBuddyId,
                    BuddyId = entity.BuddyId,
                    BuddyName = entity.Buddy.Name,
                    TripId = entity.TripId,
                };
                return additionalBuddyDetail;

            }
        }
    }
}
