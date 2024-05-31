using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.ViewModels.ProgramStudent
{
    public class QueryProgramStudent
    {

        public DateTime? MinRegisterDate {get; set;}
        public DateTime? MaxRegisterDate {get; set;}
        public string? ProgramId { get; set; }
        public string? ProgramName { get; set; }
        public string? StudentId { get; set; }
        public string? StudentName { get; set; }

    }
}