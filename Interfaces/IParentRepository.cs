using RehabilitationSystem.ViewModels.Parent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RehabilitationSystem.Interfaces
{
    public interface IParentRepository
    {
        Task<List<GetParent>?> GetAllAsync(QueryParent query, List<string> includes);
        Task<GetParent?> GetByIdAsync(string id, List<string> includes);
        Task<string?> AddAsync(AddParent parent, string AppUserId);
        Task<string?> UpdateAsync(string id, UpdateParent parent);

    }
}
