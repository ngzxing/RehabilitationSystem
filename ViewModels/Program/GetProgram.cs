using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.Session;

namespace RehabilitationSystem.ViewModels.Program
{
    public class GetProgram
    {
        public string? ProgramId { get; set; }
        public string? Name { get; set; }
        public string? Objective { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public ICollection<GetSession>? Sessions { get; set; }
        public ICollection<GetBilling>? Billings { get; set; }
    }
}