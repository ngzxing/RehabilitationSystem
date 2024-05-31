using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Data.Enum;

namespace RehabilitationSystem.ViewModels.Student
{
    public class QueryStudent
    {
        

        public string? Name { get; set; }
        public Gender? Gender { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public DateTime? MaxDOB { get; set; }
        public DateTime? MinDOB { get; set; }
        public string? ParentId { get; set; }
        public string? ParentName { get; set; }
        public string? ProgramId { get; set; }
        public string? ProgramName { get; set; }
        public DateTime? RegisterDate { get; set; }
        public bool? BillingStatus { get; set; }
    }
}