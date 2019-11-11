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
        public TripService() { }

        public IEnumerable<TripListItem> GetTrips()
        {
            using (var ctx = new ApplicationDbContext())
            {
                
                var query = ctx.Trips.Select(e => new TripListItem
                {
                    TripId = e.TripId,
                    StartLocation = e.StartLocation,
                    EndLocation = e.EndLocation,
                    PrimaryBuddyName = e.PrimaryBuddy.Name,
                    VolunteerName = e.Volunteer.Name,
                    Description = e.Description
                });
                return query.ToList();
            }
        }

        //public bool CreateTrip(TripCreate model)
        //{
        //    var entity = new Trip()
        //    {
        //        StartLocation = model.StartLocation,
                
        //    }

       // }
    }
}
