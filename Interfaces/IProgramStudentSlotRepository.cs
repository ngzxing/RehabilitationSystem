using RehabilitationSystem.ViewModels.ProgramStudentSlot;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RehabilitationSystem.Interfaces
{
    public interface IProgramStudentSlotRepository
    {
        Task<List<GetProgramStudentSlot>?> GetAllAsync(QueryProgramStudentSlot query, List<string> includes);
        Task<GetProgramStudentSlot?> GetByIdAsync(string id, List<string> includes);
        Task<string?> AddAsync(AddProgramStudentSlot viewModel);
        Task<string?> DeleteAsync(string id);
    }
}
