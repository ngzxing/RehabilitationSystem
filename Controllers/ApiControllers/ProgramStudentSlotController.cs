using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.ProgramStudentSlot;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RehabilitationSystem.Controllers.ApiControllers
{
    [Route("api/ProgramStudentSlot")]
    [ApiController]
    public class ProgramStudentSlotController : ControllerBase
    {
        private readonly IProgramStudentSlotRepository _programStudentSlotRepo;

        public ProgramStudentSlotController(IProgramStudentSlotRepository programStudentSlotRepo)
        {
            _programStudentSlotRepo = programStudentSlotRepo;
        }

        // GET: api/ProgramStudentSlot
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryProgramStudentSlot query)
        {
            List<string> includes = new List<string> { "Slot", "ProgramStudent" };
            List<GetProgramStudentSlot>? slots = await _programStudentSlotRepo.GetAllAsync(query, includes);

            if (slots == null || slots.Count == 0)
            {
                return NotFound("No program student slots found.");
            }

            return Ok(slots);
        }

        // GET: api/ProgramStudentSlot/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            List<string> includes = new List<string> { "Slot", "ProgramStudent" };
            GetProgramStudentSlot? slot = await _programStudentSlotRepo.GetByIdAsync(id, includes);

            if (slot == null)
            {
                return NotFound("Program student slot not found.");
            }

            return Ok(slot);
        }

        // POST: api/ProgramStudentSlot
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddProgramStudentSlot programStudentSlot)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string? result = await _programStudentSlotRepo.AddAsync(programStudentSlot);

            if (result != null)
            {
                return BadRequest(result);
            }

            return Ok("Program student slot added successfully.");
        }

        // DELETE: api/ProgramStudentSlot/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            string? result = await _programStudentSlotRepo.DeleteAsync(id);

            if (result != null)
            {
                return NotFound(result);
            }

            return Ok("Program student slot deleted successfully.");
        }
    }
}
