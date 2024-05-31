using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.ViewModels.ProgramStudentSlot
{
    public class AddProgramStudentSlot
    {
        
        
        [Required]
        public string? ProgramStudentId {get; set;}
    
        [Required]
        public string? SlotId {get; set;}
        
    }
}