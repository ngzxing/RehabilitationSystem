using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Repository;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.Announcement;
using RehabilitationSystem.Models;
using RehabilitationSystem.ViewModels.Program;

namespace RehabilitationSystem.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementRepository _announcementRepo;

        public AnnouncementController(IAnnouncementRepository announcementRepo)
        {
            _announcementRepo = announcementRepo;
        }
        // GET: ProgramController
        public async Task<IActionResult> Index()
        {
            List<string> includes = new List<string>() { "Admin" };
            List<GetAnnouncement>? AnnouncementVM = await _announcementRepo.GetAllAsync(includes);
            return View(AnnouncementVM);
        }

        // GET: ProgramController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            return View();
        }

        // GET: ProgramController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProgramController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddAnnouncement announcement)
        {
            try
            {
                if (ModelState.IsValid)
                    await _announcementRepo.AddAsync(announcement, "admin1");

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: ProgramController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            GetAnnouncement? getAnnouncement = await _announcementRepo.GetByIdAsync(id, new List<string>());
            //Handle null or not found
            if (getAnnouncement == null)
                return View("Create");

            var announcement = new UpdateAnnouncement
            {
                Title = getAnnouncement.Title,
                Content = getAnnouncement.Content,
                Status = getAnnouncement.Status,
            };
            return View(announcement);
        }

        // POST: ProgramController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UpdateAnnouncement announcement)
        {
            try
            {
                Console.WriteLine(id + "HAHA");
                if (ModelState.IsValid)
                    await _announcementRepo.UpdateAsync(id, announcement);
                foreach(var model in ModelState)
                {
                    Console.WriteLine(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(string id)
        {
            Console.WriteLine(id);
            try
            {
                GetAnnouncement getAnnouncement = await _announcementRepo.GetByIdAsync(id, new List<string>());
                if (getAnnouncement == null)
                {
                    return Json(new { success = false, message = "Announcement not found." });
                }

                UpdateAnnouncement announcement = new UpdateAnnouncement
                {
                    Title = getAnnouncement.Title,
                    Content = getAnnouncement.Content,
                    Status = (getAnnouncement.Status == null) ? true : !getAnnouncement.Status //Toggle Status
                };

                await _announcementRepo.UpdateAsync(id, announcement);

                return Json(new { success = true, message = "Announcement status updated successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while updating the announcement status: " + ex.Message });
            }
        }


        // GET: ProgramController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProgramController/Delete/5
        [HttpPost]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var result = await _announcementRepo.DeleteAsync(id);
                Console.WriteLine(id + "HAHA");
                if (result == null)
                {
                    return Json(new { success = true, message = "Announcement deleted successfully." });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while deleting the announcement." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
                /*return View();*/
            }
        }
    }
}
