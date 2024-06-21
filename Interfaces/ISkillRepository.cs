using System.Collections.Generic;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.Skill;

namespace RehabilitationSystem.Interfaces
{
    public interface ISkillRepository
    {
        Task<ICollection<GetSkillSet>?> GetAllSetAsync(List<string> includes);
        Task<ICollection<GetSkillCategory>?> GetAllCategoryAsync(List<string> includes);
        Task<ICollection<GetSkillLineItem>?> GetAllLineItemAsync(List<string> includes);
        Task<GetSkillSet> GetSetByIdAsync(string id, List<string> includes);
        Task<GetSkillCategory> GetCategoryByIdAsync(string id, List<string> includes);
        Task<GetSkillLineItem> GetLineItemByIdAsync(string id, List<string> includes);
        Task<(string?, string?)> AddSetAsync(AddSet vm);
        Task<(string?, string?)> AddCategoryAsync(AddCategory vm);
        Task<(string?, string?)> AddLineItemAsync(AddLineItem vm);
        Task<(string?, string?)> EditSetAsync(AddSet vm);
        Task<(string?, string?)> EditCategoryAsync(EditCategory vm);
        Task<(string?, string?)> EditLineItemAsync(EditLineItem vm);
        Task<string?> DeleteAsync(string skillLevel, string id);
    }
}
