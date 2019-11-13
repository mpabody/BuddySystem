using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddySystem.Models
{
    public class TripListItem
    {
        public int TripId { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public string Description { get; set; }
        public int PrimaryBuddyId { get; set; }
        public string PrimaryBuddyName { get; set; }
        public int VolunteerId { get; set; }
        public string VolunteerName { get; set; }

    }
}
