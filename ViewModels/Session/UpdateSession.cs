using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.ViewModels.Session
{
    public class UpdateSession
    {
       
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }

    }
}