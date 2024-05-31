using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.ProgramStudent;
using RehabilitationSystem.ViewModels.Therapist;

namespace RehabilitationSystem.ViewModels.Report
{
    public class GetReport
    {
       
        public string? ReportId {get; set;}
        public string? Title {get; set;}
        public string? Content {get; set;}
        public string? ProgramStudentId {get; set;}
        public GetProgramStudent? ProgramStudent {get; set;}
        public string? TherapistId {get; set;}
        public GetTherapist? Therapist {get; set;}
    }
}