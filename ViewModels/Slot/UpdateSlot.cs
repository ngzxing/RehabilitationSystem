using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.ViewModels.Slot
{
    public class UpdateSlotSlot
    {
        
        [Required]
        public DateTime? StartTime { get; set; }
        [Required]
        public DateTime? EndTime { get; set; }
        [Required]
        public DateTime? Date { get; set; }
    }
}