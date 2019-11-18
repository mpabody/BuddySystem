using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddySystem.Models.AdditionalBuddy
{
    public class AddAdditionalBuddy
    {
       
        public int BuddyToAddId { get; set; }
        [Required]
        public int TripId { get; set; }
        [Required]
        public string PrimaryBuddyName { get; set; }
        [Required]
        public string VolunteerName { get; set; }
        [Required]
        public string StartLocation { get; set; }
        [Required]
        public string ProjectedEndLocation { get; set; }
        public List<BuddyListItem> ListOfBuddies { get; set; }
    }
}
