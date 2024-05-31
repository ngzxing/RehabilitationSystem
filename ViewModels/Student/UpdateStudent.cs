using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Data.Enum;

namespace RehabilitationSystem.ViewModels.Student
{
    public class UpdateStudent
    {
       
        [Required]
        public string? Name { get; set; }
        [Required]
        public Gender? Gender { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        public DateTime? DOB { get; set; }

    }
}