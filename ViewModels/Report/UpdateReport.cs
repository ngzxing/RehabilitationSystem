using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.ViewModels.Report
{
    public class UpdateReport
    {
       
        [Required]
        public string? Title {get; set;}
        [Required]
        public string? Content {get; set;}
    }
}