using RehabilitationSystem.ViewModels.Report;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RehabilitationSystem.Interfaces
{
    public interface IReportRepository
    {
        Task<List<GetReport>?> GetAllAsync(QueryReport query, List<string> includes);
        Task<GetReport?> GetByIdAsync(string id, List<string> includes);
        Task<string?> AddAsync(string TherapistId, AddReport vm);
        Task<string?> UpdateAsync(string id, UpdateReport vm);
        Task<string?> DeleteAsync(string id);
    }
}
