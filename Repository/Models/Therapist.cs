using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Models
{
    public class Therapist
    {
        [Key]
        public string? TherapistId { get; set; }
        [Required]
        public string? Name { get; set; }

        [ForeignKey("AppUser")]
        [Required]
        public string? AppUserId {get; set;}
        public AppUser? AppUser {get; set;}
        public ICollection<TherapistSession>? TherapistSessions { get; set; }
        public ICollection<Report>? Reports { get; set; }
    }
}