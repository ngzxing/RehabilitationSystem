using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RehabilitationSystem.Data;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.Report;

namespace RehabilitationSystem.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _context;

        public ReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetReport>?> GetAllAsync(QueryReport query, List<string> includes)
        {
            var reports = _context.Reports.AsQueryable();

            if (!string.IsNullOrEmpty(query.Title))
                reports = reports.Where(r => r.Title!.Contains(query.Title));
            if (!string.IsNullOrEmpty(query.Content))
                reports = reports.Where(r => r.Content!.Contains(query.Content));
            if (!string.IsNullOrEmpty(query.ProgramStudentId))
                reports = reports.Where(r => r.ProgramStudentId == query.ProgramStudentId);
            if (!string.IsNullOrEmpty(query.TherapistId))
                reports = reports.Where(r => r.TherapistId == query.TherapistId);

            if (includes.Contains("Program"))
                reports = reports.Include(r => r.ProgramStudent!).ThenInclude(ps => ps.Program);
            if (includes.Contains("Student"))
                reports = reports.Include(r => r.ProgramStudent!).ThenInclude(ps => ps.Student);
    
            return await reports.ToViewModel(includes).ToListAsync();
        }

        public async Task<GetReport?> GetByIdAsync(string id, List<string> includes)
        {   
            var reports = _context.Reports.AsQueryable();

            if (includes.Contains("Program"))
                reports = reports.Include(r => r.ProgramStudent!).ThenInclude(ps => ps.Program);
            if (includes.Contains("Student"))
                reports = reports.Include(r => r.ProgramStudent!).ThenInclude(ps => ps.Student);

            var report = await reports.Where(r => r.ReportId == id).ToViewModel(includes).FirstOrDefaultAsync();

            return report;
        }

        public async Task<string?> AddAsync(string TherapistId, AddReport vm)
        {
            var programStudent = await _context.ProgramStudents.FindAsync(vm.ProgramStudentId);
            if (programStudent == null) return "No Such Student Register At this Program";

            var therapist = await _context.Therapists.FindAsync(TherapistId);
            if (therapist == null) return "Therapist Not Found";

            var report = new Report
            {
                Title = vm.Title,
                Content = vm.Content,
                ProgramStudentId = vm.ProgramStudentId,
                TherapistId = TherapistId
            };

            await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<string?> UpdateAsync(string id, UpdateReport vm)
        {
            var report = await _context.Reports.FindAsync(id);
            if (report == null) return "Report Not Found";

            report.Title = vm.Title;
            report.Content = vm.Content;

            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<string?> DeleteAsync(string id)
        {
            var report = await _context.Reports.FindAsync(id);
            if (report == null) return "Report Not Found";

            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
