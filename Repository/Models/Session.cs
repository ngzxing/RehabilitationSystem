using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Models
{
    public class Session
    {   
        [Key]
        public string? SessionId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }

        [ForeignKey("Program")]
        [Required]
        public string? ProgramId { get; set; }
        public Program? Program { get; set; }
        public ICollection<TherapistSession>? TherapistsSessions { get; set; }
    }
}