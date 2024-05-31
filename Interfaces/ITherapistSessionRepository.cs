using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.TherapistSession;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RehabilitationSystem.Interfaces
{
    public interface ITherapistSessionRepository
    {
        Task<List<GetTherapistSession>> GetAllAsync(QueryTherapistSession query, List<string> includes);
        Task<GetTherapistSession?> GetByIdAsync(string id, List<string> includes);
        Task<string?> AddAsync(AddTherapistSession addModel);
        Task<string?> DeleteAsync(string id);
    }
}
