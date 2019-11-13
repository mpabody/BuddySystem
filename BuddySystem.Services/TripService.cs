using BuddySystem.Data;
using BuddySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddySystem.Services
{
    public class TripService
    {
        private readonly Guid _userId;
        public TripService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<TripListItem> GetAllTrips()
        {
            using (var ctx = new ApplicationDbContext())
            {             
                var query = ctx.Trips.Select(e => new TripListItem
                {
                    TripId = e.TripId,
                    StartLocation = e.StartLocation,
                    EndLocation = e.EndLocation,
                    PrimaryBuddyId = e.BuddyId,
                    PrimaryBuddyName = e.Buddy.Name,
                    VolunteerId = e.VolunteerId,
                    VolunteerName = e.Volunteer.Name,
                    Description = e.Description
                });
                return query.ToList();
            }
        }
        public IEnumerable<TripListItem> GetTripsForCurrentUser()
        {
        // uses workaround method in BuddyService   
            var buddyService = new BuddyService(_userId);
            var buddy = buddyService.GetCurrentUserBuddy();
            return buddy.ListOfTrips;        
        }

        //public IEnumerable<TripListItem> GetTripsByBuddyId()
        //{

        //}

        public bool CreateTrip(TripCreate model)
        {

            var entity = new Trip()
            {
                StartTime = model.StartTime,
                BuddyId = model.PrimaryBuddyId,                              
                VolunteerId = model.VolunteerId,               
                StartLocation = model.StartLocation,
                ProjectedEndLocation = model.ProjectedEndLocation,
                EndLocation = model.EndLocation,
                EndTime = model.EndTime,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Trips.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
