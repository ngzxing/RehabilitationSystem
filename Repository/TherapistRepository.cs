using Microsoft.EntityFrameworkCore;
using RehabilitationSystem.Data;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.AppUser;
using RehabilitationSystem.ViewModels.Therapist;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Repository
{
    public class TherapistRepository : ITherapistRepository
    {
        private readonly ApplicationDbContext _context;

        public TherapistRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetTherapist>?> GetAllAsync(QueryTherapist query, List<string> includes)
        {
            var therapists = _context.Therapists.AsQueryable();

            if (!string.IsNullOrEmpty(query.Name))
                therapists = therapists.Where(t => t.Name!.Contains(query.Name));
            if (!string.IsNullOrEmpty(query.PhoneNumber))
                therapists = therapists.Include(t => t.AppUser).Where(t => t.AppUser!.PhoneNumber == query.PhoneNumber);
            if (!string.IsNullOrEmpty(query.Email))
                therapists = therapists.Include(t => t.AppUser).Where(t => t.AppUser!.Email == query.Email);

           

            return await therapists.ToViewModel(includes).ToListAsync();
        }

        public async Task<GetTherapist?> GetByIdAsync(string id, List<string> includes)
        {
            var therapists = _context.Therapists.AsQueryable();
            Console.WriteLine("MASUK");

            return await therapists.Where(t => t.TherapistId == id).ToViewModel(includes).FirstOrDefaultAsync();
        }

        public async Task<string?> AddAsync(AddTherapist vm, string appUserId)
        {
            var newTherapist = new Therapist
            {
                TherapistId = vm.TherapistId,
                Name = vm.Name,
                AppUserId = appUserId
            };

            await _context.Therapists.AddAsync(newTherapist);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<string?> UpdateAsync(string id, UpdateTherapist vm)
        {
            var existingTherapist = await _context.Therapists.FindAsync(id);
            if (existingTherapist == null) return "Therapist Not Found";

            existingTherapist.Name = vm.Name;
            await _context.SaveChangesAsync();
            return null;
        }

        
    }
}
