using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels;
using RehabilitationSystem.ViewModels.Billing;

namespace RehabilitationSystem.Interfaces
{
    public interface IBillingRepository
    {
        Task<List<GetBilling>?> GetAllAsync(BillingQuery query, List<string> includes);
        Task<GetBilling?> GetByIdAsync(string id, List<string> includes);
        Task<string?> AddAsync(AddBilling billing);
        Task<string?> UpdateAsync(string id, UpdateBilling billing);
        Task<string?> DeleteAsync(string id);
    }

   
}