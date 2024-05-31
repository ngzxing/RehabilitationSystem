using Microsoft.EntityFrameworkCore;
using RehabilitationSystem.Data;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.TherapistSession;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Repository
{
    public class TherapistSessionRepository : ITherapistSessionRepository
    {
        private readonly ApplicationDbContext _context;

        public TherapistSessionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetTherapistSession>> GetAllAsync(QueryTherapistSession query, List<string> includes)
        {
            var therapistSessions = _context.TherapistSessions.AsQueryable();

            // Apply filters based on query model
            if (!string.IsNullOrEmpty(query.TherapistId))
                therapistSessions = therapistSessions.Where(ts => ts.TherapistId == query.TherapistId);
            if (!string.IsNullOrEmpty(query.TherapistName))
                therapistSessions = therapistSessions.Where(ts => ts.Therapist!.Name!.Contains(query.TherapistName));
            if (!string.IsNullOrEmpty(query.SessionId))
                therapistSessions = therapistSessions.Where(ts => ts.SessionId == query.SessionId);
            if (!string.IsNullOrEmpty(query.SessionName))
                therapistSessions = therapistSessions.Where(ts => ts.Session!.Name!.Contains(query.SessionName));
            
           

            return await therapistSessions.ToViewModel(includes).ToListAsync();
        }

        public async Task<GetTherapistSession?> GetByIdAsync(string id, List<string> includes)
        {
            var therapistSessions = _context.TherapistSessions.AsQueryable();

            var therapistSession = await therapistSessions.ToViewModel(includes).FirstOrDefaultAsync(ts => ts.TherapistSessionId == id);

            return therapistSession;
        }

        public async Task<string?> AddAsync(AddTherapistSession addModel)
        {
            var therapistExists = await _context.Therapists.AnyAsync(t => t.TherapistId == addModel.TherapistId);
            if (!therapistExists) return "Therapist not found";

            var sessionExists = await _context.Sessions.AnyAsync(s => s.SessionId == addModel.SessionId);
            if (!sessionExists) return "Session not found";

            var therapistSession = new TherapistSession
            {
                TherapistId = addModel.TherapistId,
                SessionId = addModel.SessionId
            };

            await _context.TherapistSessions.AddAsync(therapistSession);
            await _context.SaveChangesAsync();
            return null;
        }


        public async Task<string?> DeleteAsync(string id)
        {
            var therapistSession = await _context.TherapistSessions.FindAsync(id);
            if (therapistSession == null) return "TherapistSession not found";

            _context.TherapistSessions.Remove(therapistSession);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
