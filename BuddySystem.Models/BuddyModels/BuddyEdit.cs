using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddySystem.Models.BuddyModels
{
    public class BuddyEdit
    {
        public int BuddyId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string CurrentLocation { get; set; }

        [Required]
        public bool IsApproved { get; set; }

        [Required]
        public bool IsMale { get; set; }

        [Required]
        public int Age { get; set; }

    }
}
