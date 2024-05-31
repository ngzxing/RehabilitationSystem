using System.Collections.Generic;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.ProgramStudent;

namespace RehabilitationSystem.Interfaces
{
    public interface IProgramStudentRepository
    {
        Task<List<GetProgramStudent>> GetAllAsync(QueryProgramStudent query, List<string> includes);
        Task<GetProgramStudent?> GetByIdAsync(string id, List<string> includes);
        Task<GetProgramStudent?> GetLatestAsync(List<string> includes);
        Task<string?> AddAsync(AddProgramStudent vm);
        
        Task<string?> DeleteAsync(string id);
    }
}
