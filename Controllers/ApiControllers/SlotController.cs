using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RehabilitationSystem.Interfaces;
using RehabilitationSystem.ViewModels.Slot;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RehabilitationSystem.Controllers.ApiControllers
{
    [Route("api/Slot")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        private readonly ISlotRepository _slotRepo;

        public SlotController(ISlotRepository slotRepo)
        {
            _slotRepo = slotRepo;
        }

        // GET: api/Slot
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QuerySlot query)
        {
            List<string> includes = new List<string> { "TherapistSession"};
            List<GetSlot>? slots = await _slotRepo.GetAllAsync(query, includes);

            if (slots == null || slots.Count == 0)
            {
                return NotFound("No slots found.");
            }

            return Ok(slots);
        }

        // GET: api/Slot/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            List<string> includes = new List<string> { "TherapistSession"};
            GetSlot? slot = await _slotRepo.GetByIdAsync(id, includes);

            if (slot == null)
            {
                return NotFound("Slot not found.");
            }

            return Ok(slot);
        }
    }
}
