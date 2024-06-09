using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.Program;
using RehabilitationSystem.ViewModels.ProgramStudentSlot;
using RehabilitationSystem.ViewModels.Report;
using RehabilitationSystem.ViewModels.Student;
using RehabilitationSystem.ViewModels.Billing;


namespace RehabilitationSystem.ViewModels.ProgramStudent
{
    public class GetProgramStudent
    {
        public string? ProgramStudentId { get; set; }
        public DateTime? RegisterDate {get; set;}
        public string? ProgramId { get; set; }
        public GetProgram? Program { get; set; }
        public string? StudentId { get; set; }
        public GetStudent? Student { get; set; }
        public ICollection<GetReport>? Reports {get; set;}

        public ICollection<GetProgramStudentSlot>? ProgramStudentSlots {get; set;}

        public GetBilling? Billing {get; set;}
    }
}