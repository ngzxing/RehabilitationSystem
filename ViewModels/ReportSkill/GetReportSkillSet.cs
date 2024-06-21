using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.Skill;

namespace RehabilitationSystem.ViewModels.ReportSkill
{
    public class GetReportSkillSet
    {
        
        public string? ReportSkillSetId {get; set;}
        public string? Comment {get; set;}
        public GetSkillSet? SkillSet {get; set;}
        public ICollection<GetReportSkillCategory>? ReportSkillCategories {get; set;}
    }
}