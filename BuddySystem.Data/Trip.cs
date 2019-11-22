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
        public DateTime StartTime { get; set; }
        [Required]
        [ForeignKey(nameof(Buddy))]
        
        public int BuddyId { get; set; }
        public virtual Buddy Buddy { get; set; }
        [Required]
        [ForeignKey(nameof(Volunteer))]
        public int VolunteerId { get; set; }
        public virtual Buddy Volunteer { get; set; }
        [Required]
        public string StartLocation { get; set; }
        [Required]
        public string ProjectedEndLocation { get; set; }
        [Required]
        public string EndLocation { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public virtual ICollection<AdditionalBuddy> AdditionalBuddies { get; set; }

    }
}
