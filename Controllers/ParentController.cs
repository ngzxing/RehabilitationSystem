using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Repository;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.Parent;

namespace RehabilitationSystem.Controllers
{
    public class ParentController : Controller
    {
        private readonly IParentRepository _parentRepo;

        public ParentController(IParentRepository parentRepo)
        {
            _parentRepo = parentRepo;
        }
        // GET: ProgramController
        public async Task<IActionResult> Index()
        {
            QueryParent query = new QueryParent() { };
            List<string> includes = new List<string>() { "AppUser", "Students" };
            List<GetParent> ParentVM = await _parentRepo.GetAllAsync(query, includes);
            return View(ParentVM);
        }

        // GET: ProgramController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            GetParent parentVM = await _parentRepo.GetByIdAsync(id, new List<string>() { "AppUser", "Students" });
            return View(parentVM);
        }

        // GET: ProgramController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProgramController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddParent parent, string AppUserId)
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


        // GET: ProgramController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            return View();
        }

        // POST: ProgramController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit()
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
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
