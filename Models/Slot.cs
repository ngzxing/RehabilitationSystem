using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Models
{
    public class Slot
    {   
        [Key]
        public string? SlotId { get; set; }
        [Required]
        public DateTime? StartTime { get; set; }
        [Required]
        public DateTime? EndTime { get; set; }

        [ForeignKey("TherapistSession")]
        public string? TherapistSessionId { get; set; }
        public TherapistSession? TherapistSession { get; set; }
        public ICollection<ProgramStudentSlot>? ProgramStudentSlots {get; set;}
    }
}