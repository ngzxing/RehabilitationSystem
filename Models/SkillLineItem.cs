using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Models
{
    public class SkillLineItem
    {   
        [Key]
        [Required]
        public string? SkillLineItemId {get; set;}

        [Required]
        public string? Name {get; set;}
        
        [ForeignKey("SkillCategory")]
        [Required]
        public string? SkillCategoryId {get; set;}

        public SkillCategory? SkillCategory {get; set;}

        public ICollection<ReportSkillLineItem>? ReportSkillLineItems {get; set;} 

    }
}