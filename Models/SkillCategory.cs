using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Models
{
    public class SkillCategory
    {   
        [Key]
        [Required]
        public string? SkillCategoryId {get; set;}

        [Required]
        public string? Name {get; set;}

        [ForeignKey("SkillSet")]
        [Required]
        public string? SkillSetId {get; set;}

        public SkillSet? SkillSet {get; set;}

        public ICollection<ReportSkillCategory>? ReportSkillCategories {get; set;}
        public ICollection<SkillLineItem>? SkillLineItems {get; set;}
    }
}