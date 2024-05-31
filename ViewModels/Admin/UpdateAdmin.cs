using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.AbstractViewModel;
using RehabilitationSystem.ViewModels.AppUser;

namespace RehabilitationSystem.ViewModels.Admin
{
    public class UpdateAdmin : AbstractUpdateUserViewModel
    {   
        
        [Required]
        public string? Name { get; set; }
        
    }
}