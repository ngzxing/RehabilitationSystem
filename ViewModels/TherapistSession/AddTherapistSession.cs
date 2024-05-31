using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.ViewModels.TherapistSession
{
    public class AddTherapistSession
    {
       
       
        [Required]
        public string? TherapistId {get; set;}
        [Required]
        public string? SessionId {get; set;}
        
    }
}