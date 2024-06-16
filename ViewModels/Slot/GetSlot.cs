using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.ProgramStudentSlot;
using RehabilitationSystem.ViewModels.TherapistSession;

namespace RehabilitationSystem.ViewModels.Slot
{
    public class GetSlot
    {     
        public string? SlotId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? ProgramName { get; set; }
        public string? SessionName { get; set; }
        public GetTherapistSession? TherapistSession { get; set; }
        public ICollection<GetProgramStudentSlot>? ProgramStudentSlots {get; set;}
    }
}