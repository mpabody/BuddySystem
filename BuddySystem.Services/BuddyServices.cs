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
                        Age = entity.Age                    
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
                ctx.Buddies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        //Code below is a work around
        public BuddyDetail GetCurrentUserBuddy() //Returns BuddyDetail Where List Of
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Buddies
                        .SingleOrDefault(b => b.UserId == _userId);

                var trips = ctx.Trips
                                     .Where(t => t.BuddyId == entity.BuddyId)
                                      .Select(t => new TripListItem()
                                      {
                                          TripId = t.TripId,
                                          StartLocation = t.StartLocation,
                                          EndLocation = t.EndLocation,
                                          Description = t.Description,
                                          PrimaryBuddyId = t.BuddyId,
                                          PrimaryBuddyName = t.Buddy.Name,
                                          VolunteerId = t.VolunteerId,
                                          VolunteerName = t.Volunteer.Name
                                      }).ToList();
                                
                return new BuddyDetail()
                {
                    BuddyId = entity.BuddyId,
                    Name = entity.Name,
                    CurrentLocation = entity.CurrentLocation,
                    IsApproved = entity.IsApproved,
                    IsMale = entity.IsMale,
                    Age = entity.Age,
                    ListOfTrips = trips
                };
                    
            }
        }
    }
}
