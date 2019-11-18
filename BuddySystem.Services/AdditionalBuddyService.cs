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
            return new AddAdditionalBuddy()
            {
                TripId = tripDetail.TripId,
                PrimaryBuddyName = tripDetail.PrimaryBuddy.Name,
                VolunteerName = tripDetail.Volunteer.Name,
                StartLocation = tripDetail.StartLocation,
                ProjectedEndLocation = tripDetail.ProjectedEndLocation
            };
        }

        public bool PostAdditionalBuddyToDataTable(AddAdditionalBuddy model)
        {
            var entity = new AdditionalBuddy()
            {
                TripId = model.TripId,
                BuddyId = model.BuddyToAddId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.AdditionalBuddies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public List<BuddyListItem> GetAdditionalBuddiesForATrip(Guid userId, int id)
        {
            var tripService = new TripService(userId);
            var trip = tripService.GetTripById(id);
            return trip.AdditionalBuddies;  
        }
    }
}
