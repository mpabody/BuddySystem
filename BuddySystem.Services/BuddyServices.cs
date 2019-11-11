﻿using BuddySystem.Data;
using BuddySystem.Models;
using BuddySystem.Models.BuddyModels;
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

        // Display all Buddies in a list
        public IEnumerable<BuddyListItem> GetBuddies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var buddyQuery =
                    ctx
                        .Buddies
                        .Where(b => b.UserId == _userId)
                        .Select(
                            b => new BuddyListItem
                            {
                                BuddyId = b.BuddyId,
                                Name = b. Name,
                                CurrentLocation = b.CurrentLocation,
                                IsVolunteer = b.IsVolunteer,
                                IsMale = b.IsMale,
                                Age = b.Age
                            });

                return buddyQuery.ToArray();
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
                    IsVolunteer = model.IsVolunteer,
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
                        .SingleOrDefault(b => b.BuddyId == id && b.UserId == _userId);

                return
                    new BuddyDetail
                    {
                        BuddyId = entity.BuddyId,
                        Name = entity.Name,
                        CurrentLocation = entity.CurrentLocation,
                        IsVolunteer = entity.IsVolunteer,
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
                entity.IsVolunteer = model.IsVolunteer;
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
    }
}
