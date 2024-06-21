using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.Skill;

namespace RehabilitationSystem.ViewModels.ReportSkill
{
    public class GetReportSkillCategory
    {
        public string? ReportSkillCategoryId {get; set;}
        public GetSkillCategory? SkillCategory {get; set;}
        public ICollection<GetReportSkillLineItem>? ReportSkillLineItems {get; set;}
    }
}