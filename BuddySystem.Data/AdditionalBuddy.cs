using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddySystem.Data
{
    public class AdditionalBuddy
    {
        [Key]    
        public int AdditionalBuddyId { get; set; }
        [Required]
        [ForeignKey(nameof(Buddy))]
        public int BuddyId { get; set; }
        public virtual Buddy Buddy { get; set; }
        [Required]
        [ForeignKey(nameof(Trip))]
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }     
    }
}
