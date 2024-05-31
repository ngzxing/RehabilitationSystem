using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RehabilitationSystem.Data;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.ProgramStudent;

namespace RehabilitationSystem.Repository
{
    public class ProgramStudentRepository : IProgramStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public ProgramStudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetProgramStudent>> GetAllAsync(QueryProgramStudent query, List<string> includes)
        {
            var programStudents = _context.ProgramStudents.AsQueryable();

            if (query.MinRegisterDate.HasValue)
                programStudents = programStudents.Where(ps => ps.RegisterDate >= query.MinRegisterDate.Value);
            if (query.MaxRegisterDate.HasValue)
                programStudents = programStudents.Where(ps => ps.RegisterDate <= query.MaxRegisterDate.Value);
            if (!string.IsNullOrEmpty(query.ProgramId))
                programStudents = programStudents.Where(ps => ps.ProgramId == query.ProgramId);
            if (!string.IsNullOrEmpty(query.ProgramName))
                programStudents = programStudents.Where(ps => ps.Program!.Name!.Contains(query.ProgramName));
            if (!string.IsNullOrEmpty(query.StudentId))
                programStudents = programStudents.Where(ps => ps.StudentId == query.StudentId);
            if (!string.IsNullOrEmpty(query.StudentName))
                programStudents = programStudents.Where(ps => ps.Student!.Name!.Contains(query.StudentName));


            return await programStudents.ToViewModel(includes).ToListAsync();
        }

        public async Task<GetProgramStudent?> GetLatestAsync(List<string> includes)
        {   
            var programStudents = _context.ProgramStudents.AsQueryable();

            return await programStudents.ToViewModel(includes).OrderByDescending(ps => ps.RegisterDate).FirstOrDefaultAsync();
        }

        public async Task<GetProgramStudent?> GetByIdAsync(string id, List<string> includes)
        {
            var programStudents = _context.ProgramStudents.AsQueryable();

            return await programStudents.ToViewModel(includes).FirstOrDefaultAsync(ps => ps.ProgramStudentId == id);
        }

        public async Task<string?> AddAsync(AddProgramStudent vm)
        {
            var program = await _context.Programs.FindAsync(vm.ProgramId);
            if (program == null) return "Program Not Found";

            var student = await _context.Students.FindAsync(vm.StudentId);
            if (student == null) return "Student Not Found";

            var programStudent = new ProgramStudent
            {
                RegisterDate = DateTime.Now,
                ProgramId = vm.ProgramId,
                StudentId = vm.StudentId
            };

            await _context.ProgramStudents.AddAsync(programStudent);
            await _context.SaveChangesAsync();
            return null;
        }


        public async Task<string?> DeleteAsync(string id)
        {
            var programStudent = await _context.ProgramStudents.FindAsync(id);
            if (programStudent == null) return "Such Program and Student Registration Not Found";

            _context.ProgramStudents.Remove(programStudent);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
