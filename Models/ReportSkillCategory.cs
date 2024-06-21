using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Models
{
    public class ReportSkillCategory
    {
        [Key]
        [Required]
        public string? ReportSkillCategoryId {get; set;}

        [Required]
        [ForeignKey("SkillCategory")]
        public string? SkillCategoryId {get; set;}
        public SkillCategory? SkillCategory {get; set;}


        [Required]
        [ForeignKey("ReportSkillSet")]
        public string? ReportSkillSetId{get; set;}
        public ReportSkillSet? ReportSkillSet {get; set;}

        public ICollection<ReportSkillLineItem>? ReportSkillLineItems {get; set;}
    }
}