using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Models
{
    public class Program
    {   
        [Key]
        public string? ProgramId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Objective { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public int? MaxSessions {get; set;}

        [Required]
        public int? CurrentSessions {get; set;}

        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid price")]
        [DataType(DataType.Currency)]
        [Required]
        public decimal? Price { get; set; }
        public ICollection<Session>? Sessions { get; set; }
        public ICollection<ProgramStudent>? ProgramStudents { get; set; }
        public ICollection<Billing>? Billings { get; set; }
    }
}