using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.BillingItem;


namespace RehabilitationSystem.Interfaces
{
    public interface IBillingItemRepository
    {
        Task<List<GetBillingItem>?> GetAllAsync();
        Task<GetBillingItem?> GetByIdAsync(string id);
        Task<string?> AddAsync(AddBillingItem vm);
        Task<string?> UpdateAsync(string id, UpdateBillingItem vm);
        Task<string?> DeleteAsync(string id);
    }
}

