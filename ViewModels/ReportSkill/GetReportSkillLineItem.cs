using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.Skill;

namespace RehabilitationSystem.ViewModels.ReportSkill
{
    public class GetReportSkillLineItem
    {
      
        public string? ReportSkillLineItemId {get; set;}
        public string? Comment {get; set;}
        public bool? Status {get; set;}
        public GetSkillLineItem? SkillLineItem {get; set;}
       
    }
}