using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddySystem.Models
{
    public class BuddyDetail
    {
        public int BuddyId { get; set; }
        public string Name { get; set; }
        public string CurrentLocation { get; set; }
        public bool IsApproved { get; set; }
        public bool IsMale { get; set; }
        public int Age { get; set; }
        public List<TripListItem> BuddyTrips { get; set; }
        public List<TripListItem> VolunteerTrips { get; set; }
    }
}
