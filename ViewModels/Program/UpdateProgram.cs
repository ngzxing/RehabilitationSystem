using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.ViewModels.Program
{
    public class UpdateProgram
    {
        
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Objective { get; set; }

        [Required]
        public string? Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid price")]
        [DataType(DataType.Currency)]
        [Required]
        public decimal? Price { get; set; }
        
    }
}