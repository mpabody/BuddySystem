using BuddySystem.Data;
using BuddySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddySystem.Services
{
    public class BuddyService
    {
        private readonly Guid _userId;

        public BuddyService(Guid userId)
        {
            _userId = userId;
        }

        public BuddyService() { }

        // Display all Buddies in a list
        public List<BuddyListItem> GetAllBuddies()
        { 
            using (var ctx = new ApplicationDbContext())
            {
                var buddyQuery =
                    ctx
                        .Buddies
                        .Select(
                            b => new BuddyListItem
                            {
                                BuddyId = b.BuddyId,
                                Name = b. Name,
                                CurrentLocation = b.CurrentLocation,
                                IsApproved = b.IsApproved,
                                IsMale = b.IsMale,
                                Age = b.Age
                            });

                return buddyQuery.ToList();
            }
        }

        //Display all approved volunteers
        public List<BuddyListItem> GetAllVolunteers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var buddyQuery =
                    ctx
                        .Buddies
                        .Where(b => b.IsApproved == true)
                        .Select(
                            b => new BuddyListItem
                            {
                                BuddyId = b.BuddyId,
                                Name = b.Name,
                                CurrentLocation = b.CurrentLocation,
                                IsApproved = b.IsApproved,
                                IsMale = b.IsMale,
                                Age = b.Age
                            });

                return buddyQuery.ToList();
            }
        }

        public bool CreateBuddy(BuddyCreate model)
        {
            var entity =
                new Buddy
                {
                    UserId = _userId,
                    Name = model.Name,
                    CurrentLocation = model.CurrentLocation,
                    IsApproved = model.IsApproved,
                    IsMale = model.IsMale,
                    Age = model.Age
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Buddies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public BuddyDetail GetBuddyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Buddies
                        .SingleOrDefault(b => b.BuddyId == id);

                return
                    new BuddyDetail
                    {
                        BuddyId = entity.BuddyId,
                        Name = entity.Name,
                        CurrentLocation = entity.CurrentLocation,
                        IsApproved = entity.IsApproved,
                        IsMale = entity.IsMale,
                        Age = entity.Age,
                        BuddyTrips = BuddyTripsToTripListItem(entity.BuddyTrips),
                        VolunteerTrips = BuddyTripsToTripListItem(entity.VolunteerTrips)
                    };
            }
        }


        public bool UpdateBuddy(BuddyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Buddies
                        .SingleOrDefault(b => b.BuddyId == model.BuddyId && b.UserId == _userId);

                entity.Name = model.Name;
                entity.CurrentLocation = model.CurrentLocation;
                entity.IsApproved = model.IsApproved;
                entity.IsMale = model.IsMale;
                entity.Age = model.Age;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBuddy(int buddyId) // Admin only?? -- UserId (line 114) prob not wanted since this will be for Admin only

        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Buddies
                        .SingleOrDefault(b => b.BuddyId == buddyId && b.UserId == _userId);
                var tripChanges = entity.BuddyTrips.Count + entity.VolunteerTrips.Count;
                for (int i = 0; i < entity.BuddyTrips.Count; i++)
                {
                    var trip = entity.BuddyTrips.ElementAt(0);
                    ctx.Trips.Remove(trip);
                }
                for (int i = 0; i < entity.VolunteerTrips.Count; i++)
                {
                    var trip = entity.VolunteerTrips.ElementAt(0);
                    var ghost = ctx.Buddies.FirstOrDefault(b => b.UserId == Guid.Parse("00000000-0000-0000-0000-000000000000"));
                    trip.BuddyId = ghost.BuddyId;
                }
                
                ctx.Buddies.Remove(entity);

                return ctx.SaveChanges() == tripChanges + 1;
            }
        }

        
        public BuddyDetail GetCurrentUserBuddy()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Buddies
                        .SingleOrDefault(b => b.UserId == _userId);
                var trips = new List<TripListItem>(){};
                foreach(var trip in entity.BuddyTrips)
                {
                    var tripToAdd = new TripListItem()
                    {
                        TripId = trip.TripId,
                        StartLocation = trip.StartLocation,
                        EndLocation = trip.EndLocation,
                        Description = trip.Description,
                        BuddyId = trip.BuddyId,
                        BuddyName = trip.Buddy.Name,
                        VolunteerId = trip.VolunteerId,
                        VolunteerName = trip.Volunteer.Name,
                    };
                    trips.Add(tripToAdd);
                }

                return new BuddyDetail()
                {
                    BuddyId = entity.BuddyId,
                    Name = entity.Name,
                    CurrentLocation = entity.CurrentLocation,
                    IsApproved = entity.IsApproved,
                    IsMale = entity.IsMale,
                    Age = entity.Age,
                    BuddyTrips = BuddyTripsToTripListItem(entity.BuddyTrips),
                    VolunteerTrips = BuddyTripsToTripListItem(entity.VolunteerTrips)
                };                             
            }
        }
            private List<TripListItem> BuddyTripsToTripListItem(ICollection<Trip> buddyTrips)
        {
            var trips = new List<TripListItem>() { };
            foreach (var trip in buddyTrips)
            {
                var tripToAdd = new TripListItem()
                {
                    TripId = trip.TripId,
                    StartLocation = trip.StartLocation,
                    EndLocation = trip.EndLocation,
                    Description = trip.Description,
                    BuddyId = trip.BuddyId,
                    BuddyName = trip.Buddy.Name,
                    VolunteerId = trip.VolunteerId,
                    VolunteerName = trip.Volunteer.Name,
                };
                trips.Add(tripToAdd);
            }
            return trips;
        }
    }
}
