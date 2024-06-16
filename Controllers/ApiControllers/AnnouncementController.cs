using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.Announcement;


namespace RehabilitationSystem.Controllers.ApiControllers
{
    [Route("api/Announcement")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementRepository _announcementRepo;

        public AnnouncementController(IAnnouncementRepository announcementRepo)
        {
            _announcementRepo = announcementRepo;
        }

        // GET: api/Announcement
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<string> includes = new List<string>();
            List<GetAnnouncement>? announcements = await _announcementRepo.GetAllAsync(includes);

            if (announcements == null || announcements.Count == 0)
            {
                return NotFound("No announcements found.");
            }

            return Ok(announcements);
        }

        // GET: api/Announcement/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            List<string> includes = new List<string>();
            GetAnnouncement? announcement = await _announcementRepo.GetByIdAsync(id, includes);

            if (announcement == null)
            {
                return NotFound("Announcement not found.");
            }

            return Ok(announcement);
        }
    }
}
