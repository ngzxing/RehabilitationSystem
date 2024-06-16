using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Repository;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.Student;
using RehabilitationSystem.ViewModels.ProgramStudent;

namespace RehabilitationSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IProgramStudentRepository _programStudentRepo;

        public StudentController(IStudentRepository studentRepo, IProgramStudentRepository programStudentRepo)
        {
            _studentRepo = studentRepo;
            _programStudentRepo = programStudentRepo;
        }
        // GET: ProgramController
        public async Task<IActionResult> Index()
        {
            QueryStudent query = new QueryStudent() { };
            List<string> includes = new List<string>() { "Parent", "ProgramStudents" };
            List<GetStudent> studentVM = await _studentRepo.GetAllAsync(query, includes);

            ICollection<GetProgramStudent>? allProgramStudents = new List<GetProgramStudent>();

            // Loop through each student
            foreach (var student in studentVM)
            {
                // Retrieve detailed information for each ProgramStudent associated with the current student
                foreach (var programStudent in student.ProgramStudents)
                {
                    GetProgramStudent detailedProgramStudent = await _programStudentRepo.GetByIdAsync(programStudent.ProgramStudentId, new List<string>() { "Program" });

                    // Append the detailed ProgramStudent information to the list
                    if (detailedProgramStudent != null)
                    {
                        allProgramStudents.Add(detailedProgramStudent);
                    }
                }

                student.ProgramStudents = allProgramStudents;
            }

            return View(studentVM);
        }

        // GET: ProgramController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            GetStudent studentVM = await _studentRepo.GetByIdAsync(id, new List<string>() { "Parent", "ProgramStudents" });

            ICollection<GetProgramStudent>? allProgramStudents = new List<GetProgramStudent>();

            foreach (var programStudent in studentVM.ProgramStudents)
            {
                GetProgramStudent detailedProgramStudent = await _programStudentRepo.GetByIdAsync(programStudent.ProgramStudentId, new List<string>() { "Program" , "ProgramStudentSlots" });

                // Append the detailed ProgramStudent information to the list
                if (detailedProgramStudent != null)
                {
                    allProgramStudents.Add(detailedProgramStudent);
                }
            }

            studentVM.ProgramStudents = allProgramStudents.OrderByDescending(ps => ps.RegisterDate).ToList(); ;

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
