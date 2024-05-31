using Microsoft.EntityFrameworkCore;
using RehabilitationSystem.Data;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.ProgramStudentSlot;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Repository
{
    public class ProgramStudentSlotRepository : IProgramStudentSlotRepository
    {
        private readonly ApplicationDbContext _context;

        public ProgramStudentSlotRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetProgramStudentSlot>?> GetAllAsync(QueryProgramStudentSlot query, List<string> includes)
        {
            var slots = _context.ProgramStudentSlots.AsQueryable();

            if (!string.IsNullOrEmpty(query.ProgramStudentId))
                slots = slots.Where(s => s.ProgramStudentId == query.ProgramStudentId);
            if (query.MinSlotStartTime.HasValue)
                slots = slots.Where(s => s.Slot!.StartTime >= query.MinSlotStartTime.Value);
            if (query.MaxSlotStartTime.HasValue)
                slots = slots.Where(s => s.Slot!.StartTime <= query.MaxSlotStartTime.Value);
            if (query.MinSlotEndTime.HasValue)
                slots = slots.Where(s => s.Slot!.EndTime >= query.MinSlotEndTime.Value);
            if (query.MaxSlotEndTime.HasValue)
                slots = slots.Where(s => s.Slot!.EndTime <= query.MaxSlotEndTime.Value);

            return await slots.ToViewModel(includes).ToListAsync();
        }

        public async Task<GetProgramStudentSlot?> GetByIdAsync(string id, List<string> includes)
        {
            var slots = _context.ProgramStudentSlots.AsQueryable();

            var slot = await slots.ToViewModel(includes).FirstOrDefaultAsync(s => s.ProgramStudentSlotId == id);

            return slot;
        }

        public async Task<string?> AddAsync(AddProgramStudentSlot viewModel)
        {
            var sessionId = await _context.Slots
                                        .Where(s => s.SlotId == viewModel.SlotId)
                                        .Select(
                                            s => s.TherapistSession!.SessionId
                                        )
                                        .FirstOrDefaultAsync();
            if (sessionId == null) return "Slot Not Found";

            var programStudentExists = await _context.ProgramStudents.AnyAsync(ps => ps.ProgramStudentId == viewModel.ProgramStudentId);
            if (!programStudentExists) return "ProgramStudent Not Found";

            var duplicate = await _context.ProgramStudentSlots.AnyAsync(
                
                pss => ( pss.ProgramStudentId == viewModel.ProgramStudentId ) && (pss.Slot!.TherapistSession!.SessionId == sessionId)
            );
            if (duplicate) return "You Have Register This Session";

            var newProgramStudentSlot = new ProgramStudentSlot
            {
                ProgramStudentId = viewModel.ProgramStudentId,
                SlotId = viewModel.SlotId
            };

            await _context.ProgramStudentSlots.AddAsync(newProgramStudentSlot);
            await _context.SaveChangesAsync();

            return null;
        }

        

        public async Task<string?> DeleteAsync(string id)
        {
            var programStudentSlot = await _context.ProgramStudentSlots.FindAsync(id);
            if (programStudentSlot == null) return "ProgramStudentSlot Not Found";

            _context.ProgramStudentSlots.Remove(programStudentSlot);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
