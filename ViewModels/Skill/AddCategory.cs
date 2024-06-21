using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.ViewModels.Skill
{
    public class AddCategory
    {
        [Required]
        public string? SkillCategoryId {get; set;}
        [Required]
        public string? SkillSetId {get; set;}
        [Required]
        public string? Name {get; set;}

    }
}