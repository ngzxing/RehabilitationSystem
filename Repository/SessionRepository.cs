using Microsoft.EntityFrameworkCore;
using RehabilitationSystem.Data;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.Session;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ApplicationDbContext _context;

        public SessionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetSession>?> GetAllAsync( List<string> includes)
        {
            var sessions = _context.Sessions.AsQueryable();


            return await sessions.ToViewModel(includes).ToListAsync();
        }

        public async Task<GetSession?> GetByIdAsync(string id, List<string> includes)
        {
            var sessions = _context.Sessions.AsQueryable();


            return await sessions.ToViewModel(includes).FirstOrDefaultAsync(s => s.SessionId == id);
        }

        public async Task<string?> AddAsync(AddSession vm)
        {
            var programExists = await _context.Programs.AnyAsync(p => p.ProgramId == vm.ProgramId);
            if (!programExists) return "Program Not Found";

            var session = new Session
            {
                Name = vm.Name,
                Description = vm.Description,
                ProgramId = vm.ProgramId
            };

            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<string?> UpdateAsync(string id, UpdateSession vm)
        {
            var session = await _context.Sessions.FindAsync(id);
            if (session == null) return "Session Not Found";

            session.Name = vm.Name;
            session.Description = vm.Description;

            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<string?> DeleteAsync(string id)
        {
            var session = await _context.Sessions.FindAsync(id);
            if (session == null) return "Session Not Found";

            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
