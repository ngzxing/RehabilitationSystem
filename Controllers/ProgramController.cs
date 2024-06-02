using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Repository;
using RehabilitationSystem.Interfaces;

namespace RehabilitationSystem.Controllers
{
    public class ProgramController : Controller
    {
        private readonly IProgramRepository _program;

        public ProgramController(IProgramRepository program)
        {
            _program = program;
        }
        // GET: ProgramController
        public IActionResult Index()
        {
/*            ProgramQuery query = new ProgramQuery() { };
            List<string> includes = new List<string> { " " };
            List<GetProgram> ProgramVM = await _program.GetAllAsync(query, includes);*/
            return View();
        }

        // GET: ProgramController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProgramController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProgramController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
