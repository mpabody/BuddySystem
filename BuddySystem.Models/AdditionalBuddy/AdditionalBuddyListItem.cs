using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddySystem.Models.AdditionalBuddy
{ // used BuddyListItem instead for GetAdditionalBuddiesForATrip -- keeping this for now, just in case we use it
    public class AdditionalBuddyListItem
    {   
        public int AdditionalBuddyId { get; set; }
        public int BuddyId { get; set; }     
        public string Name { get; set; }

    }
}
