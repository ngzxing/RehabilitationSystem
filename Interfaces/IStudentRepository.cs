using System.Collections.Generic;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.Student;

namespace RehabilitationSystem.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<GetStudent>?> GetAllAsync(QueryStudent query, List<string> includes);
        Task<GetStudent?> GetByIdAsync(string id, List<string> includes);
        Task<string?> AddAsync(string ParentId, AddStudent vm);
        Task<string?> UpdateAsync(string id, UpdateStudent vm);
        Task<string?> DeleteAsync(string id);
    }
}
