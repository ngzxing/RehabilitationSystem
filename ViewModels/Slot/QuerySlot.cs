using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.ViewModels.Slot
{
    public class QuerySlot
    {
        
        public DateTime? MinStartTime { get; set; } = DateTime.Now;
        public DateTime? MaxStartTime { get; set; }
        public DateTime? MinEndTime { get; set; }
        public DateTime? MaxEndTime { get; set; }
        public string? TherapistId { get; set; }
        public string? SessionId { get; set; }
        public string? StudentId {get; set;}
        public string? ProgramId {get; set;}
        
    }
}