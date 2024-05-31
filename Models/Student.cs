using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Data.Enum;

namespace RehabilitationSystem.Models
{
    public class Student
    {   
        [Key]
        public string? StudentId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public Gender? Gender { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        public DateTime? DOB { get; set; }

        [Required]
        [ForeignKey("Parent")]
        public string? ParentId { get; set; }
        public Parent? Parent { get; set; }
        public ICollection<ProgramStudent>? ProgramStudents { get; set; }
        public ICollection<Billing>? Billings { get; set; }
    }
}