using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.ViewModels.ProgramStudentSlot
{
    public class QueryProgramStudentSlot
    {
        
        public string? ProgramStudentId {get; set;}
        public DateTime? MinSlotStartTime {get; set;}
        public DateTime? MaxSlotStartTime {get; set;}
        public DateTime? MinSlotEndTime {get; set;}
        public DateTime? MaxSlotEndTime {get; set;}
    }
}