using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.ViewModels.Report
{
    public class QueryReport
    {
       
        public string? Title {get; set;}
        public string? Content {get; set;}
        public string? ProgramStudentId {get; set;}
        public string? TherapistId {get; set;}
    }
}