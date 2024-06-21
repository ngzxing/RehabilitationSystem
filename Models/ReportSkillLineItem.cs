using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Models
{
    public class ReportSkillLineItem
    {
        [Key]
        [Required]
        public string? ReportSkillLineItemId {get; set;}

        [Required]
        public string? Comment {get; set;}

        [Required]
        public bool? Status {get; set;}

        [Required]
        [ForeignKey("SkillLineItem")]
        public string? SkillLineItemId {get; set;}
        public SkillLineItem? SkillLineItem {get; set;}

        [Required]
        [ForeignKey("ReportSkillCategory")]
        public string? ReportSkillCategoryId {get; set;}
        public ReportSkillCategory? ReportSkillCategory {get; set;}



        
    }
}