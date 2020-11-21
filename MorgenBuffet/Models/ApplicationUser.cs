using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MorgenBuffet.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [PersonalData]  
        public string Name { get; set; }
    }
}
