using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Repository;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.Program;
using RehabilitationSystem.ViewModels.Therapist;
using RehabilitationSystem.Extensions;


namespace RehabilitationSystem.Areas.Therapist.Controllers
{
    [Area("Therapist")]
    public class ProgramController : Controller
    {
        private readonly IProgramRepository _programRepo;
        private readonly ITherapistRepository _therapistRepo;
        private readonly IExtendUserRepository _extendUserRepo;

        public ProgramController(IProgramRepository programRepo, ITherapistRepository therapistRepo, IExtendUserRepository extendUserRepo)
        {
            _programRepo = programRepo;
            _therapistRepo = therapistRepo;
            _extendUserRepo = extendUserRepo;
    }
        // GET: ProgramController
        public async Task<IActionResult> Index()
        {
            ProgramQuery query = new ProgramQuery() { };
            List<string> includes = new List<string>() { "Sessions" };
            List<GetProgram> ProgramVM = await _programRepo.GetAllAsync(query, includes);
            return View(ProgramVM);
        }

        // GET: ProgramController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            GetProgram ProgramVM = await _programRepo.GetByIdAsync(id, new List<string>() { "Sessions" });
            //Handle null or not found
            if (ProgramVM == null)
                return View();

            return View(ProgramVM);
        }

        // GET: ProgramController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProgramController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddProgram program)
        {
            try
            {
                if (ModelState.IsValid)
                    await _programRepo.AddAsync(program);
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
            GetProgram? getProgram = await _programRepo.GetByIdAsync(id, new List<string>());
            //Handle null or not found
            if (getProgram == null) 
                return View();

            var program = new UpdateProgram
            {
                Name = getProgram.Name,
                Objective = getProgram.Objective,
                Description = getProgram.Description,
                Price = getProgram.Price
            };
            return View(program);
        }

        // POST: ProgramController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UpdateProgram program)
        {
            try
            {
                if (ModelState.IsValid)
                    await _programRepo.UpdateAsync(id, program);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
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
                var result = await _programRepo.DeleteAsync(id);
                Console.WriteLine(id + "HAHA");
                if (result == null)
                {
                    return Json(new { success = true, message = "Program deleted successfully." });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while deleting the program." });
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
/*                return View();
*/          }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ProgramQuery query = new ProgramQuery() { };
            List<GetProgram> programVM = await _programRepo.GetAllAsync(query, new List<string>());
            foreach (var program in programVM)
            {
                Console.WriteLine(program.Name);
            }
            return Json(programVM);
        }

        [HttpGet]
        public async Task<IActionResult> GetSessionsByProgramId([FromQuery] string programId)
        {
            Console.WriteLine(programId);
            try
            {
                // Use programId to fetch sessions or perform necessary operations
                GetProgram programVM = await _programRepo.GetByIdAsync(programId, new List<string> { "Sessions" });
                var programFilteredSession = programVM.Sessions;

                foreach (var session in programFilteredSession)
                {
                    Console.WriteLine(session.Name);
                }

                var (user, err_msg) = await User.GetCurrentUserId(_extendUserRepo);

                // Handle the case where user is not found or there's an error
                if (user == null)
                {
                    return BadRequest("User not found: " + err_msg);
                }

                Console.WriteLine("HALO");
                Console.WriteLine(user.ExtendUserId);
                GetTherapist therapistVM = await _therapistRepo.GetByIdAsync(user.ExtendUserId, new List<string> { "Sessions" });
                var therapistFilteredSession = therapistVM.Sessions;

                foreach (var session in therapistFilteredSession)
                {
                    Console.WriteLine(session.Name);
                }

                // Find the intersection of programFilteredSession and therapistFilteredSession
                var filteredSessions = programFilteredSession
                    .Where(session => therapistFilteredSession.Any(ts => ts.SessionId == session.SessionId))
                    .ToList();

                foreach(var session in filteredSessions)
                {
                    Console.WriteLine(session.Name);
                }

                return Json(filteredSessions);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("Error fetching sessions: " + ex.Message);
            }
        }

    }
}
