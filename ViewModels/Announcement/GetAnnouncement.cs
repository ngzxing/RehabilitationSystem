using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.ViewModels.Admin;

namespace RehabilitationSystem.ViewModels.Announcement
{
    public class GetAnnouncement
    {
        public string? AnnouncementId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime? Date { get; set; }
        public bool? Status { get; set; }
        public string? AdminId { get; set; }
        public GetAdmin? Admin { get; set; }
    }
}