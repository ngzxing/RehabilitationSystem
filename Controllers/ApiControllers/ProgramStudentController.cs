using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.ProgramStudent;

namespace RehabilitationSystem.Controllers.ApiControllers
{
    [Route("api/ProgramStudent")]
    [ApiController]
    public class ProgramStudentController : ControllerBase
    {
        private readonly IProgramStudentRepository _programStudentRepo;

        public ProgramStudentController(IProgramStudentRepository programStudentRepo)
        {
            _programStudentRepo = programStudentRepo;
        }

        // GET: api/ProgramStudent
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryProgramStudent query)
        {
            List<string> includes = new List<string> { "Program", "Student" };
            List<GetProgramStudent> programStudents = await _programStudentRepo.GetAllAsync(query, includes);

            if (programStudents == null || programStudents.Count == 0)
            {
                return NotFound("No program students found.");
            }

            return Ok(programStudents);
        }

/*        // GET: api/ProgramStudent/latest
        [HttpGet("latest")]
        public async Task<IActionResult> GetLatest()
        {
            List<string> includes = new List<string> { "Program", "Student" };
            GetProgramStudent? programStudent = await _programStudentRepo.GetLatestAsync(includes);

            if (programStudent == null)
            {
                return NotFound("No program students found.");
            }

            return Ok(programStudent);
        }*/

        // GET: api/ProgramStudent/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            List<string> includes = new List<string> { "Program", "Student" };
            GetProgramStudent? programStudent = await _programStudentRepo.GetByIdAsync(id, includes);

            if (programStudent == null)
            {
                return NotFound("Program student not found.");
            }

            return Ok(programStudent);
        }

        // POST: api/ProgramStudent
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddProgramStudent programStudent)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string? result = await _programStudentRepo.AddAsync(programStudent);

            if (result != null)
            {
                return BadRequest(result);
            }

            return Ok("Program added successfully.");
        }

/*        // DELETE: api/ProgramStudent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            string? result = await _programStudentRepo.DeleteAsync(id);

            if (result != null)
            {
                return NotFound(result);
            }

            return Ok("Program deleted successfully.");
        }*/
    }
}
