using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.ViewModels.Billing
{
    public class UpdateBilling
    {
        [Required]
        public string? ProgramStudentId { get; set; }
        
    }
}