using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.ViewModels.AppUser
{
    public class UpdateAppUser
    {
        
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}