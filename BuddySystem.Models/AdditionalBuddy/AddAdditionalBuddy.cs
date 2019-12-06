using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddySystem.Models
{
    public class AddAdditionalBuddy
    {
       
        [Required]
        public int BuddyId { get; set; }
        [Required]
        public int TripId { get; set; }
        public string BuddyName { get; set; }
        public string VolunteerName { get; set; }
        public string StartLocation { get; set; }
        public string ProjectedEndLocation { get; set; }
        public List<BuddyListItem> ListOfBuddies { get; set; }
    }
}
