using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Repository;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.Program;

namespace RehabilitationSystem.Controllers
{
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
            List<string> includes = new List<string>();
            List<GetProgram> ProgramVM = await _programRepo.GetAllAsync(query, includes);
            return View(ProgramVM);
        }

        // GET: ProgramController/Details/5
        public ActionResult Details(int id)
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
        public async Task<IActionResult> Create(AddProgram program)
        {
            try
            {
                await _programRepo.AddAsync(program);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProgramController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProgramController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
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
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
