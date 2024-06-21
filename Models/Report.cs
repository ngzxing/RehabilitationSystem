using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Data.Enum;

namespace RehabilitationSystem.Models
{
    public class Report
    {   
        [Key]
        public string? ReportId {get; set;}

        [Required]
        public string? Content {get; set;}

        [Required]
        public TreatmentCategory? Category {get; set;}

        public ICollection<ReportSkillSet>? SkillSets {get; set;}

        [Required]
        [ForeignKey("ProgramStudent")]
        public string? ProgramStudentId {get; set;}
        public ProgramStudent? ProgramStudent {get; set;}

        [Required]
        [ForeignKey("Therapist")]
        public string? TherapistId {get; set;}
        public Therapist? Therapist {get; set;}
        

    }
}