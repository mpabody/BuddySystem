using BuddySystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddySystem.Models
{
    public class TripDetail
    {
        [Key]
        public int TripId { get; set; }
        public DateTime StartTime { get; set; }

        public int BuddyId { get; set; }
        public string BuddyName { get; set; }
        public int VolunteerId { get; set; }
        public string VolunteerName { get; set; }
        public string StartLocation { get; set; }
        public string ProjectedEndLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime EndTime { get; set; }
        public List<BuddyListItem> AdditionalBuddies { get; set; }
    }
}
