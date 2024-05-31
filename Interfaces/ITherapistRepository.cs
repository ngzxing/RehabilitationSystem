using RehabilitationSystem.ViewModels.Therapist;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RehabilitationSystem.Interfaces
{
    public interface ITherapistRepository
    {
        Task<List<GetTherapist>?> GetAllAsync(QueryTherapist query, List<string> includes);
        Task<GetTherapist?> GetByIdAsync(string id, List<string> includes);
        Task<string?> AddAsync(AddTherapist therapist, string appUserId);
        Task<string?> UpdateAsync(string id, UpdateTherapist therapist);

    }
}
