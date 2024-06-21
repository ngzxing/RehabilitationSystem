using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.ViewModels.Skill
{
    public class GetSkillCategory
    {
       
        public string? SkillCategoryId {get; set;}
        public string? Name {get; set;}
        public ICollection<GetSkillLineItem>? SkillLineItems {get; set;}
    }
}