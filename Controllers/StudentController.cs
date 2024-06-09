using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Repository;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.Student;

namespace RehabilitationSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepo;

        public StudentController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }
        // GET: ProgramController
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: ProgramController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            GetStudent studentVM = await _studentRepo.GetByIdAsync(id, new List<string>() { "Parent", "ProgramStudents" });
            return View(studentVM);
        }

        // GET: ProgramController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProgramController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddStudent student)
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
