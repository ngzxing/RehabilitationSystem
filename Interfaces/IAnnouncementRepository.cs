using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.Announcement;

namespace RehabilitationSystem.Interfaces
{
    public interface IAnnouncementRepository
    {
        Task<List<GetAnnouncement>?> GetAllAsync( List<string> includes);
        Task<GetAnnouncement?> GetByIdAsync(string id, List<string> includes);
        Task<string?> AddAsync(AddAnnouncement vm, string AdminId);
        Task<string?> UpdateAsync(string id, UpdateAnnouncement vm);
    }
}