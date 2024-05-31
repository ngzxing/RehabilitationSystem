using RehabilitationSystem.ViewModels.Session;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RehabilitationSystem.Interfaces
{
    public interface ISessionRepository
    {
        Task<List<GetSession>?> GetAllAsync(List<string> includes);
        Task<GetSession?> GetByIdAsync(string id, List<string> includes);
        Task<string?> AddAsync(AddSession addSession);
        Task<string?> UpdateAsync(string id, UpdateSession updateSession);
        Task<string?> DeleteAsync(string id);
    }
}
