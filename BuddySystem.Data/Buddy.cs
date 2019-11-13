using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddySystem.Data
{
    public class Buddy
    {
        [Required]
        public Guid UserId { get; set; }

        [Key]
        public int BuddyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CurrentLocation { get; set; } // Should be set by GPS - no option to edit?

        public bool IsVolunteer { get; set; }

        // added 11/10

        [Required]
        public bool IsMale { get; set; }

        [Required]
        public int Age { get; set; }
        
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
