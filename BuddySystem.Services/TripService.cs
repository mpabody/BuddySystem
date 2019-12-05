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
                    BuddyId = e.BuddyId,
                    BuddyName = e.Buddy.Name,
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
            return buddy.BuddyTrips;
        }

        //public IEnumerable<TripListItem> GetTripsByBuddyId()
        //{

        //}

        public bool CreateTrip(TripCreate model)
        {

            var entity = new Trip()
            {
                StartTime = model.StartTime,
                BuddyId = model.BuddyId,
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

        public bool UpdateTrip(TripEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Trips
                    .SingleOrDefault(t => t.TripId == model.TripId);

                entity.StartTime = model.StartTime;
                entity.BuddyId = model.BuddyId;
                
                entity.VolunteerId = model.VolunteerId;
                entity.StartLocation = model.StartLocation;
                entity.ProjectedEndLocation = model.ProjectedEndLocation;
                entity.EndLocation = model.EndLocation;
                entity.EndTime = model.EndTime;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTrip(int tripId)

        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trips
                        .SingleOrDefault(t => t.TripId == tripId);
                ctx.Trips.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public TripDetail GetTripById(int id)// -- need to make user specific
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trips
                        .SingleOrDefault(b => b.TripId == id);
                var additionalBuddies = new List<BuddyListItem>();
                foreach(var buddy in entity.AdditionalBuddies)
                {
                    var b = new BuddyListItem()
                    {
                        BuddyId = buddy.BuddyId,
                        Name = buddy.Buddy.Name,
                        CurrentLocation = buddy.Buddy.CurrentLocation,
                        IsApproved = buddy.Buddy.IsApproved,
                        IsMale = buddy.Buddy.IsMale,
                        Age = buddy.Buddy.Age
                    };
                    additionalBuddies.Add(b);
                }
                return new TripDetail
                {
                    TripId = entity.TripId,
                    StartTime = entity.StartTime,
                    BuddyId = entity.BuddyId,
                    BuddyName = entity.Buddy.Name,
                    VolunteerId = entity.VolunteerId,
                    VolunteerName = entity.Volunteer.Name,
                    StartLocation = entity.StartLocation,
                    ProjectedEndLocation = entity.ProjectedEndLocation,
                    EndLocation = entity.EndLocation,
                    EndTime = entity.EndTime,
                    AdditionalBuddies = additionalBuddies
                };
            }
        }
    }
}
