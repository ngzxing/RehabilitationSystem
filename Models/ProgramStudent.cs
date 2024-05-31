using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Models
{
    public class ProgramStudent
    {   
        
        [Key]
        public string? ProgramStudentId { get; set; }

        [Required]
        public DateTime? RegisterDate {get; set;}

        [Required]
        public string? ProgramId { get; set; }
        public Program? Program { get; set; }

        [Required]
        public string? StudentId { get; set; }
        public Student? Student { get; set; }

        public ICollection<Report>? Reports {get; set;}
        public Billing? Billing {get; set;}
        public ICollection<ProgramStudentSlot>? ProgramStudentSlots {get; set;}
    }
}