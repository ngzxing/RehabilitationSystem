using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Models
{
    public class TherapistSession
    {
        [Key]
        public string? TherapistSessionId {get; set;}

        [ForeignKey("Therapist")]
        [Required]
        public string? TherapistId {get; set;}
        public Therapist? Therapist {get; set;}

        [ForeignKey("Session")]
        [Required]
        public string? SessionId {get; set;}
        public Session? Session {get; set;}

        public ICollection<Slot>? Slots {get; set;} 

        
    }
}