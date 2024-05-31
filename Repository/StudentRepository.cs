using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RehabilitationSystem.Data;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.Student;

namespace RehabilitationSystem.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetStudent>?> GetAllAsync(QueryStudent query, List<string> includes)
        {
            var students = _context.Students.AsQueryable();

            // Filtering based on query parameters
            if (!string.IsNullOrEmpty(query.Name))
                students = students.Where(s => s.Name!.Contains(query.Name));
            if (query.Gender.HasValue)
                students = students.Where(s => s.Gender == query.Gender);
            if (query.MinAge.HasValue)
                students = students.Where(s => s.Age >= query.MinAge);
            if (query.MaxAge.HasValue)
                students = students.Where(s => s.Age <= query.MaxAge);
            if (query.MinDOB.HasValue)
                students = students.Where(s => s.DOB >= query.MinDOB);
            if (query.MaxDOB.HasValue)
                students = students.Where(s => s.DOB <= query.MaxDOB);
            if (!string.IsNullOrEmpty(query.ParentId))
                students = students.Where(s => s.ParentId == query.ParentId);
            if (!string.IsNullOrEmpty(query.ParentName))
                students = students.Where(s => s.Parent!.Name!.Contains(query.ParentName));
            if (!string.IsNullOrEmpty(query.ProgramId))
                students = students.Where(s => s.ProgramStudents!.Any(ps => ps.ProgramId == query.ProgramId));
            if (!string.IsNullOrEmpty(query.ProgramName))
                students = students.Where(s => s.ProgramStudents!.Any(ps => ps.Program!.Name!.Contains(query.ProgramName)));
            if (query.RegisterDate.HasValue)
                students = students.Where(s => s.ProgramStudents!.Any(ps => ps.RegisterDate == query.RegisterDate));
            if (query.BillingStatus.HasValue)
                students = students.Where(s => s.Billings!.Any(b => b.PaymentStatus == query.BillingStatus));

            if (includes.Contains("Program"))
                students = students.Include(s => s.ProgramStudents!).ThenInclude(ts => ts.Program);

            return await students.ToViewModel(includes).ToListAsync();
        }

        public async Task<GetStudent?> GetByIdAsync(string id, List<string> includes)
        {
            var students = _context.Students.AsQueryable();

            if (includes.Contains("Program"))
                students = students.Include(s => s.ProgramStudents!).ThenInclude(ts => ts.Program);


            return await students.Where(s => s.StudentId == id).ToViewModel(includes).FirstOrDefaultAsync();
        }

        public async Task<string?> AddAsync(string ParentId, AddStudent vm)
        {
            var parentExists = await _context.Parents.AnyAsync(p => p.ParentId == ParentId);
            if (!parentExists)
                return "Parent Not Found";

            var student = new Student
            {
                StudentId = vm.StudentId,
                Name = vm.Name,
                Gender = vm.Gender,
                Age = vm.Age,
                DOB = vm.DOB,
                ParentId = ParentId
            };

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<string?> UpdateAsync(string id, UpdateStudent vm)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return "Student Not Found";

            student.Name = vm.Name;
            student.Gender = vm.Gender;
            student.Age = vm.Age;
            student.DOB = vm.DOB;

            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<string?> DeleteAsync(string id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return "Student Not Found";

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
