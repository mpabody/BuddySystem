using BuddySystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddySystem.Models
{
    public class TripCreate
    {
        [Required]
        public string StartLocation { get; set; }
        [Required] // might be an address that will convert to a latitude/longitude upon completion
        public string ProjectedEndLocation { get; set; }
        [Required]
        public int PrimaryBuddyId { get; set; }
        public virtual Buddy PrimaryBuddy { get; set; }
        [Required]
        public int VolunteerId { get; set; }
        public virtual Buddy Volunteer { get; set; }
    }
}
