using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.ProgramStudent;
using RehabilitationSystem.ViewModels.Slot;

namespace RehabilitationSystem.ViewModels.ProgramStudentSlot
{
    public class GetProgramStudentSlot
    {
        public string? ProgramStudentSlotId {get; set;}
        public string? ProgramStudentId {get; set;}
        public GetProgramStudent? ProgramStudent {get; set;}
        public string? SlotId {get; set;}
        public GetSlot? Slot {get; set;}
    }
}