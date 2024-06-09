using System.Collections.Generic;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.Slot;

namespace RehabilitationSystem.Interfaces
{
    public interface ISlotRepository
    {
        Task<List<GetSlot>?> GetAllAsync(QuerySlot query, List<string> includes);
        Task<GetSlot?> GetByIdAsync(string id, List<string> includes);
        Task<string?> AddAsync(AddSlot slot);
        Task<string?> UpdateAsync(string id, UpdateSlot slot);
        Task<string?> DeleteAsync(string id);
    }
}
