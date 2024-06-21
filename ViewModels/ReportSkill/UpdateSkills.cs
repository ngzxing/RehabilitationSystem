using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.ViewModels.ReportSkill
{
    public class UpdateSkills
    {   
        [Required]
        public ICollection<UpdateSkill>? Updates {get; set;}

    }
}