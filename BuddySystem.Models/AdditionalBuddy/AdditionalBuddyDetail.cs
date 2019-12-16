using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddySystem.Models.AdditionalBuddy
{
    public class AdditionalBuddyDetail
    {
        public int AdditionalBuddyId { get; set; }
        public int BuddyId { get; set; }
        public string BuddyName { get; set; }
        public int TripId { get; set; }
    }
}
