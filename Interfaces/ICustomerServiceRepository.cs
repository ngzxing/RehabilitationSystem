using RehabilitationSystem.ViewModels.CustomerService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RehabilitationSystem.Interfaces
{
    public interface ICustomerServiceRepository
    {
        Task<List<GetCustomerService>?> GetAllAsync(QueryCustomerService query, List<string> includes);
        Task<GetCustomerService?> GetByIdAsync(string id, List<string> includes);
        Task<string?> AddAsync(AddCustomerService customerService, string appUserId);
        Task<string?> UpdateAsync(string id, UpdateCustomerService customerService);
    }
}
