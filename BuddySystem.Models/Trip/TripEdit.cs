using BuddySystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddySystem.Models
{
    public class TripEdit
    {
        [Key]
        public int TripId { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public int BuddyId { get; set; }
        [Required]
        public int VolunteerId { get; set; }
        [Required]
        public string StartLocation { get; set; }
        [Required]
        public string ProjectedEndLocation { get; set; }
        [Required]
        public string EndLocation { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
    }
}
