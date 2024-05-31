using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.AbstractViewModel;
using RehabilitationSystem.ViewModels.AppUser;

namespace RehabilitationSystem.ViewModels.Parent
{
    public class UpdateParent : AbstractUpdateUserViewModel
    {
        
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Postcode { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Occupation { get; set; }
        
    }
}