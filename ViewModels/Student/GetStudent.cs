using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Data.Enum;
using RehabilitationSystem.ViewModels.Parent;
using RehabilitationSystem.ViewModels.ProgramStudent;
using RehabilitationSystem.ViewModels.Billing;


namespace RehabilitationSystem.ViewModels.Student
{
    public class GetStudent
    {
        public string? StudentId { get; set; }
        public string? Name { get; set; }
        public Gender? Gender { get; set; }
        public int? Age { get; set; }
        public DateTime? DOB { get; set; }
        public string? ParentId { get; set; }
        public GetParent? Parent { get; set; }
        public ICollection<GetProgramStudent>? ProgramStudents { get; set; }
        public ICollection<GetBilling>? Billings { get; set; }
    }
}