using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.Announcement;
using RehabilitationSystem.ViewModels.AppUser;

namespace RehabilitationSystem.ViewModels.Admin
{
    public class GetAdmin
    {
        [Required]
        public string? AdminId { get; set; }
        [Required]
        public string? Name { get; set; }
        public GetAppUser? AppUser {get; set;}
        public ICollection<GetAnnouncement>? Announcements {get; set;}
    }
}