using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.ReportSkill;

namespace RehabilitationSystem.ViewModels.Skill
{
    public class GetSkillSet
    {
        public string? SkillSetId {get; set;}
        public string? Name {get; set;}
        public  string? Description {get; set;}
        public ICollection<GetSkillCategory>? SkillCategories {get; set;}
    }
}