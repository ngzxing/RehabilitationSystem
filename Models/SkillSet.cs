using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Models
{
    public class SkillSet
    {   
        [Key]
        [Required]
        public string? SkillSetId {get; set;}

        [Required]
        public string? Name {get; set;}

        [Required]
        public  string? Description {get; set;}

        public ICollection<SkillCategory>? SkillCategories {get; set;}
        public ICollection<ReportSkillSet>? ReportSkillSets {get; set;}

    }
}