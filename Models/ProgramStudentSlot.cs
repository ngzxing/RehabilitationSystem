using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Models
{
    public class ProgramStudentSlot
    {
        [Key]
        public string? ProgramStudentSlotId {get; set;}
        
        [ForeignKey("ProgramStudent")]
        [Required]
        public string? ProgramStudentId {get; set;}
        public ProgramStudent? ProgramStudent {get; set;}

        [ForeignKey("Slot")]
        [Required]
        public string? SlotId {get; set;}
        public Slot? Slot {get; set;}

    }
}