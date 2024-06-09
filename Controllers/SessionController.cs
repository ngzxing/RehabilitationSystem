using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Repository;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.Session;


namespace RehabilitationSystem.Controllers
{
    public class SessionController : Controller
    {
        private readonly ISessionRepository _sessionRepo;

        public SessionController(ISessionRepository sessionRepo)
        {
            _sessionRepo = sessionRepo;
        }
        // GET: ProgramController
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: ProgramController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            return View();
        }

        // GET: ProgramController/Create
        public IActionResult Create(string id)
        {
            ViewData["ProgramId"] = id;
            return View();
        }

        // POST: ProgramController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddSession session)
        {
            try
            {
                var result = await _sessionRepo.AddAsync(session);
                return RedirectToAction("Details", "Program", new { id = session.ProgramId });
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(string id, string programId)
        {
            GetSession? getSession = await _sessionRepo.GetByIdAsync(id, new List<string>());
            //Handle null or not found
            if (getSession == null)
                return View();

            var session = new UpdateSession
            {
                Name = getSession.Name,
                Description = getSession.Description,
            };

            return View(session);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, string programId, UpdateSession session)
        {
            try
            {
                if (ModelState.IsValid)
                    await _sessionRepo.UpdateAsync(id, session);
                Console.WriteLine(programId);
                return RedirectToAction("Details", "Program", new { id = programId }) ;
            }
            catch
            {
                return View();
            }
        }

        // POST: ProgramController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        /*[ValidateAntiForgeryToken]*/
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var result = await _sessionRepo.DeleteAsync(id);
                Console.WriteLine(id + "HAHA");
                if (result == null)
                {
                    return Json(new { success = true, message = "Session deleted successfully." });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while deleting the session." });
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
