using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RehabilitationSystem.Data;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.Slot;

namespace RehabilitationSystem.Repository
{
    public class SlotRepository : ISlotRepository
    {
        private readonly ApplicationDbContext _context;

        public SlotRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetSlot>?> GetAllAsync(QuerySlot query, List<string> includes)
        {
            var slots = _context.Slots.AsQueryable();

            if (query.MinStartTime.HasValue)
                slots = slots.Where(s => s.StartTime >= query.MinStartTime.Value);
            if (query.MaxStartTime.HasValue)
                slots = slots.Where(s => s.StartTime <= query.MaxStartTime.Value);
            if (query.MinEndTime.HasValue)
                slots = slots.Where(s => s.EndTime >= query.MinEndTime.Value);
            if (query.MaxEndTime.HasValue)
                slots = slots.Where(s => s.EndTime <= query.MaxEndTime.Value);
            if (!string.IsNullOrEmpty(query.TherapistId))
                slots = slots.Where(s => s.TherapistSession!.TherapistId == query.TherapistId);
            if (!string.IsNullOrEmpty(query.SessionId))
                slots = slots.Where(s => s.TherapistSession!.SessionId == query.SessionId);
            if (!string.IsNullOrEmpty(query.StudentId))
                slots = slots.Where(s => s.ProgramStudentSlots!.Any(pss => pss.ProgramStudent!.StudentId == query.StudentId));
            if (!string.IsNullOrEmpty(query.ProgramId))
                slots = slots.Where(s => s.ProgramStudentSlots!.Any(pss => pss.ProgramStudent!.ProgramId == query.ProgramId));

            
                                
            return await slots.ToViewModel(includes).ToListAsync();
        }

        public async Task<GetSlot?> GetByIdAsync(string id, List<string> includes)
        {
            var slots = _context.Slots.AsQueryable();

            var slot = await slots.ToViewModel(includes).FirstOrDefaultAsync(s => s.SlotId == id);

            return slot;
        }

        public async Task<string?> AddAsync(AddSlot vm)
        {   
            var ts = await _context.TherapistSessions.AnyAsync( s => s.TherapistSessionId == vm.TherapistSessionId);
            if (ts == false) return "No Such Therapist with this session Found";

            var slot = new Slot
            {
                StartTime = vm.StartTime,
                EndTime = vm.EndTime,
                TherapistSessionId = vm.TherapistSessionId
            };

            await _context.Slots.AddAsync(slot);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<string?> UpdateAsync(string id, UpdateSlotSlot vm)
        {
            var slot = await _context.Slots.FindAsync(id);
            if (slot == null) return "Slot Not Found";

            slot.StartTime = vm.StartTime;
            slot.EndTime = vm.EndTime;

            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<string?> DeleteAsync(string id)
        {
            var slot = await _context.Slots.FindAsync(id);
            if (slot == null) return "Slot Not Found";

            _context.Slots.Remove(slot);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
