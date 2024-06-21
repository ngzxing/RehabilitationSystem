using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Models
{
    public class ReportSkillSet
    {   
        [Key]
        [Required]
        public string? ReportSkillSetId {get; set;}

        [Required]
        public string? Comment {get; set;}

        [ForeignKey("Report")]
        [Required]
        public string? ReportId {get; set;}
        public Report? Report {get; set;}

        [ForeignKey("SkillSet")]
        [Required]
        public string? SkillSetId {get; set;}
        public SkillSet? SkillSet {get; set;}

        public ICollection<ReportSkillCategory>? ReportSkillCategories {get; set;}
    }
}