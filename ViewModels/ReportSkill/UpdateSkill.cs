using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.ViewModels.ReportSkill
{
    public class UpdateSkill
    {   

        [Required]
        public string? ReportSkillLineItemId {get; set;}

        [Required]
        public bool? Status {get; set;}
        [Required]
        public string? Comment {get; set;}
    }
}