using System.Collections.Generic;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.Program;

namespace RehabilitationSystem.Interfaces
{
    public interface IProgramRepository
    {
        Task<List<GetProgram>> GetAllAsync(ProgramQuery query, List<string> includes);
        Task<GetProgram?> GetByIdAsync(string id, List<string> includes);
        Task<string?> AddAsync(AddProgram vm);
        Task<string?> UpdateAsync(string id, UpdateProgram vm);
        Task<string?> DeleteAsync(string id);
    }
}
