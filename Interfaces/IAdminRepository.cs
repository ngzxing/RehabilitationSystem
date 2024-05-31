using RehabilitationSystem.ViewModels.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RehabilitationSystem.Interfaces
{
    public interface IAdminRepository
    {
        Task<List<GetAdmin>?> GetAllAsync( QueryAdmin query, List<string> includes);
        Task<GetAdmin?> GetByIdAsync(string id, List<string> includes);
        Task<string?> AddAsync(AddAdmin admin, string AppUserId);
        Task<string?> UpdateAsync(string id, UpdateAdmin admin);
    
    }
}
