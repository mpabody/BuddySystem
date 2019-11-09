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
        public Guid UserID { get; set; }

        [Key]
        public int BuddyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CurrentLocation { get; set; }

        public bool IsVolunteer { get; set; }
    }
}
