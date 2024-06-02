using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RehabilitationSystem.Data;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.Announcement;

namespace RehabilitationSystem.Repository
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly ApplicationDbContext _context;

        public AnnouncementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetAnnouncement>?> GetAllAsync(List<string> includes)
        {
            var announcements = _context.Announcements.AsQueryable();
            

            return await announcements.ToViewModel(includes).ToListAsync();
        }

        public async Task<GetAnnouncement?> GetByIdAsync(string id, List<string> includes)
        {
            var announcements = _context.Announcements.AsQueryable();

            return await announcements.Where(a => a.AnnouncementId == id).ToViewModel(includes).FirstOrDefaultAsync();
        }

        public async Task<string?> AddAsync(AddAnnouncement vm, string AdminId)
        {
            var newAnnouncement = new Announcement
            {
                Title = vm.Title,
                Content = vm.Content,
                Date = DateTime.Now,
                Status = false,
                AdminId = AdminId
            };

            await _context.Announcements.AddAsync(newAnnouncement);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<string?> UpdateAsync(string id, UpdateAnnouncement vm)
        {
            var existingAnnouncement = await _context.Announcements.FindAsync(id);
            if (existingAnnouncement == null) return "Announcement Not Found";

            existingAnnouncement.Title = vm.Title;
            existingAnnouncement.Content = vm.Content;
            existingAnnouncement.Status = vm.Status;

            await _context.SaveChangesAsync();
            return null;
        }

       
    }
}
