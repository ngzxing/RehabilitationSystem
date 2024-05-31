using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.ViewModels.ProgramStudent
{
    public class AddProgramStudent
    {

        [Required]
        public string? ProgramId { get; set; }

        [Required]
        public string? StudentId { get; set; }

    }
}