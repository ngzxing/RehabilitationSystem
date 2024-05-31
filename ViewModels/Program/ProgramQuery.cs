using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.ViewModels.Program
{
    public class ProgramQuery
    {
        public string? Name { get; set; }
        public string? Objective { get; set; }
        public decimal? MaxPrice { get; set; }
        public decimal? MinPrice { get; set; }
        
    }
}