using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Repository;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.Program;

namespace RehabilitationSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProgramController : Controller
    {
        private readonly IProgramRepository _programRepo;

        public ProgramController(IProgramRepository programRepo)
        {
            _programRepo = programRepo;
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

        /*public IActionResult Upsert(string? id)
        {
            if (id == null || id == 0)
            {
                //create
                return View();
            }
            else
            {
                //update
                UpsertProgram program = _programRepo.
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id, includeProperties: "ProductImages");
                return View(productVM);
            }
        }*/

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
                return Json(programVM.Sessions);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("Error fetching sessions: " + ex.Message);
            }
        }

    }
}
