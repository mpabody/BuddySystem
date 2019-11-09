using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddySystem.Data
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }
        //Start & End Location types will change when we implement external APIs
        [Required]
        public string StartLocation { get; set; }

        public string EndLocation { get; set; }
        [Required]
        [ForeignKey("Buddy")]
        public string PrimaryBuddyId { get; set; }
        public virtual Buddy PrimaryBuddy { get; set; }
        public int VolunteerId { get; set; }
        public virtual Buddy Volunteer { get; set; }
    }
}
