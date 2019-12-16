using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddySystem.Models.AdminModels
{
    public class UserInfo
    {     
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
    }
}
