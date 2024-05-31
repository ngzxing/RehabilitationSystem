using Microsoft.EntityFrameworkCore;
using RehabilitationSystem.Data;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.Admin;
using RehabilitationSystem.ViewModels.AppUser;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehabilitationSystem.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetAdmin>?> GetAllAsync(QueryAdmin query, List<string> includes)
        {
            var admins = _context.Admins.AsQueryable();

            if (!string.IsNullOrEmpty(query.Name))
                admins = admins.Where(a => a.Name!.Contains(query.Name));
            if (!string.IsNullOrEmpty(query.PhoneNumber))
                admins = admins.Include(a => a.AppUser).Where(a => a.AppUser!.PhoneNumber == query.PhoneNumber);
            if (!string.IsNullOrEmpty(query.Email))
                admins = admins.Include(a => a.AppUser).Where(a => a.AppUser!.Email == query.Email);
            

            return await admins.ToViewModel(includes).ToListAsync();
        }

        public async Task<GetAdmin?> GetByIdAsync(string id, List<string> includes)
        {
            var admins = _context.Admins.AsQueryable();

            return await admins.Where(a => a.AdminId == id).ToViewModel(includes).FirstOrDefaultAsync();
        }

        public async Task<string?> AddAsync(AddAdmin vm, string AppUserId)
        {
            var newAdmin = new Admin
            {
                AdminId = vm.AdminId,
                Name = vm.Name,
                AppUserId = AppUserId
            };

            await _context.Admins.AddAsync(newAdmin);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<string?> UpdateAsync(string id, UpdateAdmin vm)
        {
            var existingAdmin = await _context.Admins.FindAsync(id);
            if (existingAdmin == null) return "Admin Not Found";

            existingAdmin.Name = vm.Name;

            await _context.SaveChangesAsync();
            return null;
        }

       
    }
}
