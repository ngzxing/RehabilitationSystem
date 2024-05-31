using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Models;

namespace RehabilitationSystem.ViewModels
{
    public class AddBilling
    {
        
        [Required]
        public string? ProgramStudentId { get; set; }
        
        
    }
}