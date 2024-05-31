using Microsoft.EntityFrameworkCore;
using RehabilitationSystem.Data;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.AppUser;
using RehabilitationSystem.ViewModels.Parent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Repository
{
    public class ParentRepository : IParentRepository
    {
        private readonly ApplicationDbContext _context;

        public ParentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetParent>?> GetAllAsync(QueryParent query, List<string> includes)
        {
            var parents = _context.Parents.AsQueryable();

            if (!string.IsNullOrEmpty(query.Name))
                parents = parents.Where(p => p.Name!.Contains(query.Name));
            if (!string.IsNullOrEmpty(query.City))
                parents = parents.Where(p => p.City!.Contains(query.City));
            if (!string.IsNullOrEmpty(query.Postcode))
                parents = parents.Where(p => p.Postcode!.Contains(query.Postcode));
            if (!string.IsNullOrEmpty(query.State))
                parents = parents.Where(p => p.State!.Contains(query.State));
            if (!string.IsNullOrEmpty(query.Address))
                parents = parents.Where(p => p.Address!.Contains(query.Address));
            if (!string.IsNullOrEmpty(query.Occupation))
                parents = parents.Where(p => p.Occupation!.Contains(query.Occupation));
            if (!string.IsNullOrEmpty(query.PhoneNumber))
                parents = parents.Include(p => p.AppUser).Where(p => p.AppUser!.PhoneNumber == query.PhoneNumber);
            if (!string.IsNullOrEmpty(query.Email))
                parents = parents.Include(p => p.AppUser).Where(p => p.AppUser!.Email == query.Email);

           

            return await parents.ToViewModel(includes).ToListAsync();
        }

        public async Task<GetParent?> GetByIdAsync(string id, List<string> includes)
        {
            var parents = _context.Parents.AsQueryable();

            var parent = await parents.Where(p => p.ParentId == id).ToViewModel(includes).FirstOrDefaultAsync();

            return parent;
        }

        public async Task<string?> AddAsync(AddParent parent, string AppUserId)
        {
            var newParent = new Parent
            {
                ParentId = parent.ParentId,
                Name = parent.Name,
                City = parent.City,
                Postcode = parent.Postcode,
                State = parent.State,
                Address = parent.Address,
                Occupation = parent.Occupation,
                AppUserId = AppUserId
            };

            await _context.Parents.AddAsync(newParent);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<string?> UpdateAsync(string id, UpdateParent parent)
        {
            var existingParent = await _context.Parents.FindAsync(id);
            if (existingParent == null) return "Parent Not Found";

            existingParent.Name = parent.Name;
            existingParent.City = parent.City;
            existingParent.Postcode = parent.Postcode;
            existingParent.State = parent.State;
            existingParent.Address = parent.Address;
            existingParent.Occupation = parent.Occupation;

            await _context.SaveChangesAsync();
            return null;
        }

 
    }
}
